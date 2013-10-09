using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*   Весь  проект  настолько  кривой,  что  даже не собираюсь  лезть  и  
 * что-то менять  в нем.
 * 
 *   В этом файле осуществляется логика работы с контрагентами.
 */
namespace Avalon
{

    struct KladrSt
    {
        public String reg_id;
        public String region;


        public KladrSt(String id, String reg, String type)
        {
            reg_id = id;
            region = reg + ", " + type;

        }
    };
    /*Контрагенты*/
    class Contragent
    {

        public Int32 ContrId;  /*Нужен для работы с запросами*/
        public Int32 cond;     /*Для внутренней логики*/

        /*Прямо как поля в базе*/
        public String INN;
        public String KPP;
        public String OrgName;
        public String RCode;

        public override String ToString(){
            return INN + "/" + KPP + " " + OrgName;
        }


    };

    /*Лицензии контрагентов*/
    class Licence 
    {
        public Int32 LicId;    /*ИД для запросов*/
        public Int32 cond;     /*Для обработки внутренней логики*/
        public Int32 ContrId;  /*Для доступа к контрагенту по словарю*/

        /*Поля из базы*/
        public String series;
        public String number;
        public String dateBegin;
        public String dateEnd;
        public Int32  typeid;
 
        public override String ToString()
        {
            return "Серия: " + series + " Номер: " + number + "  Период: " + dateBegin + "-" + dateEnd ;
        }
    };

    /*  Не будем себя загружать и сделаем - одна операция, одна строка. Каждый
     * параметр разделяют точка с запятой. Эти поля базы не должны содержать
     * точки с запятой.
     */
    class Operation
    {
        public Contragent cont;
        public Licence    lic;

        public Int32      OpId;         /*ИД Операции*/
        public String     VarParam;     /*Некоторое количество оставшихся параметров. Если список, то разделен через |*/
        public Int32      cond;         /*Внутреннее состояние*/
        OperationView       view;

        public Operation(int id, OperationView func)
        {
            OpId = id;
            cont = new Contragent();
            lic  = new Licence();
            VarParam = "";
            view = func;
            cond = 0;
        }

        /*Делегат сам все сделает*/
        public override string ToString()
        {
            return view(this);
        }
    };

    enum OpList
    {
        REMOVE_LICENCE_BY_NUMBER = 1,                      /*Удаление ненужной лицензии по номеру*/
        REMOVE_LICENCE_BY_SERIES_NUMBER,                   /*Удаление лицензии по серии и номеру*/
        REMOVE_LICENCE_BY_CONTR_INN_KPP,                   /*Удаление лицензии по ИНН КПП Контрагента*/
        CHANGE_LICENCE_NUMBER_BY_SERIES_AND_NUMBER,        /*Смена номера и серии по известному номеру и серии*/
        CHANGE_LICENCE_DATE_BY_NUMBER,                     /*Смена даты лицензии по известному номеру (в случае опечатки)*/
        REMOVING_LICENCE_BY_INN_KPP_EX,                    /*Удаление всех лицензий кроме используемых (чистка)*/
        REMOVE_CONTRAGENT_BY_ID,                           /*Единичное удаление контрагента*/
        CHANGE_KPP_BY_INN_KPP,                             /*Смена КПП по ИНН, при смене КПП компаний*/
        REMOVE_CONTRAGENT_BY_INN_KPP,                      /*Удаление контрагента по ИНН КПП*/
        RENAME_CONTRAGENT_BY_INN_KPP,                      /*Смена имени контрагента по ИНН КПП*/
        RENAME_CONTRAGENT_BY_INN_KPP_REGION                /*Специальная маска, которая правильно именует филиалы*/
    };

    delegate void      OperationHandler(Operation op);      /*Выполняет операцию*/
    delegate string    OperationView   (Operation op);      /*Отображает операцию*/
    delegate Operation OperationCreate (Contragent contr,   /*Создание операции*/
                                        Licence lic, string value);

    /*Класс только исполняет операции*/
    class ContragentOperations
    {

        Dictionary<String, String> Kladr;

        /*Объявления передаваемых функций*/
        public delegate void      QueryFunc(string query);
        public delegate DataRow[] QueryRFunc(string query);

        /*Непосредственно сами функции*/
        QueryFunc  query;
        QueryRFunc queryR;

        public void SetQueryFunctions(QueryFunc f1, QueryRFunc f2)
        {
            query = f1;
            queryR = f2;
        }

        private String CreateContragent(Contragent cont)
        {
            return cont.INN + "/" + cont.KPP;
        }


        

        public ContragentOperations(string basename)
        {

            Kladr = new Dictionary<String,String>();
            /*А вот список прямо из Базы Декларант-Алко*/
                Kladr["01"] = "Адыгея" + ", " + "Респ";
                Kladr["02"] = "Башкортостан" + ", " + "Респ";
                Kladr["03"] = "Бурятия" + ", " + "Респ";
                Kladr["04"] = "Алтай" + ", " + "Респ";
                Kladr["05"] = "Дагестан" + ", " + "Респ";
                Kladr["06"] = "Ингушетия" + ", " + "Респ";
                Kladr["07"] = "Кабардино-Балкарская" + ", " + "Респ";
                Kladr["08"] = "Калмыкия" + ", " + "Респ";
                Kladr["09"] = "Карачаево-Черкесская" + ", " + "Респ";
                Kladr["10"] = "Карелия" + ", " + "Респ";
                Kladr["11"] = "Коми" + ", " + "Респ";
                Kladr["12"] = "Марий Эл" + ", " + "Респ";
                Kladr["13"] = "Мордовия" + ", " + "Респ";
                Kladr["14"] = "Саха /Якутия/" + ", " + "Респ";
                Kladr["15"] = "Северная Осетия - Алания" + ", " + "Респ";
                Kladr["16"] = "Татарстан" + ", " + "Респ";
                Kladr["17"] = "Тыва" + ", " + "Респ";
                Kladr["18"] = "Удмуртская" + ", " + "Респ";
                Kladr["19"] = "Хакасия" + ", " + "Респ";
                Kladr["20"] = "Чеченская" + ", " + "Респ";
                Kladr["21"] = "Чувашская Республика -" + ", " + "Чувашия";
                Kladr["22"] = "Алтайский" + ", " + "край";
                Kladr["23"] = "Краснодарский" + ", " + "край";
                Kladr["24"] = "Красноярский" + ", " + "край";
                Kladr["25"] = "Приморский" + ", " + "край";
                Kladr["26"] = "Ставропольский" + ", " + "край";
                Kladr["27"] = "Хабаровский" + ", " + "край";
                Kladr["28"] = "Амурская" + ", " + "обл";
                Kladr["29"] = "Архангельская" + ", " + "обл";
                Kladr["30"] = "Астраханская" + ", " + "обл";
                Kladr["31"] = "Белгородская" + ", " + "обл";
                Kladr["32"] = "Брянская" + ", " + "обл";
                Kladr["33"] = "Владимирская" + ", " + "обл";
                Kladr["34"] = "Волгоградская" + ", " + "обл";
                Kladr["35"] = "Вологодская" + ", " + "обл";
                Kladr["36"] = "Воронежская" + ", " + "обл";
                Kladr["37"] = "Ивановская" + ", " + "обл";
                Kladr["38"] = "Иркутская" + ", " + "обл";
                Kladr["39"] = "Калининградская" + ", " + "обл";
                Kladr["40"] = "Калужская" + ", " + "обл";
                Kladr["41"] = "Камчатский" + ", " + "край";
                Kladr["42"] = "Кемеровская" + ", " + "обл";
                Kladr["43"] = "Кировская" + ", " + "обл";
                Kladr["44"] = "Костромская" + ", " + "обл";
                Kladr["45"] = "Курганская" + ", " + "обл";
                Kladr["46"] = "Курская" + ", " + "обл";
                Kladr["47"] = "Ленинградская" + ", " + "обл";
                Kladr["48"] = "Липецкая" + ", " + "обл";
                Kladr["49"] = "Магаданская" + ", " + "обл";
                Kladr["50"] = "Московская" + ", " + "обл";
                Kladr["51"] = "Мурманская" + ", " + "обл";
                Kladr["52"] = "Нижегородская" + ", " + "обл";
                Kladr["53"] = "Новгородская" + ", " + "обл";
                Kladr["54"] = "Новосибирская" + ", " + "обл";
                Kladr["55"] = "Омская" + ", " + "обл";
                Kladr["56"] = "Оренбургская" + ", " + "обл";
                Kladr["57"] = "Орловская" + ", " + "обл";
                Kladr["58"] = "Пензенская" + ", " + "обл";
                Kladr["59"] = "Пермский" + ", " + "край";
                Kladr["60"] = "Псковская" + ", " + "обл";
                Kladr["61"] = "Ростовская" + ", " + "обл";
                Kladr["62"] = "Рязанская" + ", " + "обл";
                Kladr["63"] = "Самарская" + ", " + "обл";
                Kladr["64"] = "Саратовская" + ", " + "обл";
                Kladr["65"] = "Сахалинская" + ", " + "обл";
                Kladr["66"] = "Свердловская" + ", " + "обл";
                Kladr["67"] = "Смоленская" + ", " + "обл";
                Kladr["68"] = "Тамбовская" + ", " + "обл";
                Kladr["69"] = "Тверская" + ", " + "обл";
                Kladr["70"] = "Томская" + ", " + "обл";
                Kladr["71"] = "Тульская" + ", " + "обл";
                Kladr["72"] = "Тюменская" + ", " + "обл";
                Kladr["73"] = "Ульяновская" + ", " + "обл";
                Kladr["74"] = "Челябинская" + ", " + "обл";
                Kladr["75"] = "Забайкальский" + ", " + "край";
                Kladr["76"] = "Ярославская" + ", " + "обл";
                Kladr["77"] = "Москва" + ", " + "г";
                Kladr["78"] = "Санкт-Петербург" + ", " + "г";
                Kladr["79"] = "Еврейская" + ", " + "Аобл";
                Kladr["83"] = "Ненецкий" + ", " + "АО";
                Kladr["86"] = "Ханты-Мансийский Автономный округ - Югра" + ", " + "АО";
                Kladr["87"] = "Чукотский" + ", " + "АО";
                Kladr["89"] = "Ямало-Ненецкий" + ", " + "АО";
                Kladr["99"] = "Байконур" + ", " + "г";

          
        }


        /*Методы выполнения операций*/
        public void RemoveLicenceByNumber(Operation Op) {
            string com = "DELETE FROM wrk_contr_licenses WHERE number = '"
                + Op.lic.number + "'";
            query(com);
        }
        public void RemoveLicenceBySeriesNumber(Operation Op) {
            
            string com = "DELETE FROM wrk_contr_licenses WHERE number = '" + Op.lic.number + "' AND series = '" + Op.lic.series + "'" ;
            query(com);
        }
        public void RemoveLicenceByContrInnKpp(Operation Op) {
            
            string com = "DELETE FROM wrk_contr_licenses WHERE ref_contr_id IN (SELECT id FROM wrk_Contragents WHERE INN = '"
                         + Op.cont.INN + "' AND KPP = '" + Op.cont.KPP + "')";
            query(com);
        }
        public void ChangeLicenceNumberBySeriesAndNumber(Operation Op) {
            
            string com = "UPDATE wrk_contr_licenses SET number = '" + Op.VarParam
                + "' WHERE series = '" + Op.lic.series + "' AND number = '" + Op.lic.number + "'";
            query(com);
        }
        public void ChangeLicenceDateByNumber(Operation Op) { }
        public void RemovingLicenceByInnKppEx(Operation Op) {
            /* 
             * Это чуть сложнее запросом чем предыдущее. Однако лицензии используются
             * только в 4 видах таблиц, что означает уменьшенную сложность для разработчика
             * 2 раза IN с вложенными запросами все решит
             */
            string com =
            "DELETE FROM wrk_contr_licenses WHERE id IN (" +
                                        "SELECT id FROM (SELECT id, idLic FROM wrk_contr_licenses c " +
		                                        "LEFT JOIN (SELECT idLic FROM  DecF11 UNION " +
			                                       "SELECT idLic FROM  DecF7  UNION "         +
		                                           "SELECT idLic FROM  DecF6  UNION "         +
			                                       "SELECT idLic FROM  DecF8) a ON a.idLic = c.id ) inn "+
                                                   " WHERE idLic IS NULL) " +
                                        "AND ref_contr_id IN ( " +
                                            "SELECT id FROM wrk_Contragents WHERE INN = '" +
                                             Op.cont.INN + "' AND KPP = '" + Op.cont.KPP + "')";
            query(com);
        }
        public void ChangeKppByInnKpp(Operation Op) {

            string com = "UPDATE wrk_Contragents SET KPP = '" + Op.VarParam +
                "' WHERE INN = '" + Op.cont.INN + "' AND KPP = '" + Op.cont.KPP + "'";

            query(com);
        
        }
        public void RemoveContragentByInnKpp(Operation Op) { 

            string com = "DELETE FROM wrk_Contragents WHERE KPP = '" +
                Op.cont.KPP + "' AND INN = '" + Op.cont.INN + "'";

            query(com);
        }
        public void RenameContragentByInnKpp(Operation Op) {
            string com = "UPDATE SET OrgName = '" + Op.VarParam + "' WHERE KPP = '" +
                Op.cont.KPP + "' AND INN = '" + Op.cont.INN + "'";
        }
        public void RenameContragentByInnKppRegion(Operation Op) {
           /* Удаление ненужных лицензий хотя бы шло одним запросом.
            * Здесь нужно взять всех контрагентов по ИНН, затем
            * получить их КПП, и переименовать каждый по маске
            */
            string TmpName = Op.VarParam;
            string INN     = Op.cont.INN;

            DataRow[] dr = queryR("SELECT KPP FROM wrk_Contragents WHERE INN = '" + INN + "'");


            int  ixKPP = 0;

            /*Запрос на обновление должен осуществляться для каждой записи*/
            for (int ix = 0; ix < dr.Length; ix++)
            {
                string KPP        = dr[ix][ixKPP].ToString();

                /*Кому нужна точность до города? Вам? Ждем коммита.*/
                string FullName = TmpName + " (" + Kladr[KPP.Substring(0, 2)] + ")";

                string com = "UPDATE wrk_Contragents SET OrgName = '"
                    + FullName + "' WHERE INN = '" + INN + "' AND KPP = '" + KPP + "'";

                query(com);
            }


        }
        public void RemoveContragentById(Operation Op) { }

        /*Методы отображения операций*/
        public string ShowRemoveLicenceByNumber(Operation Op) { 
            return "Удалить лицензии с номером " + Op.lic.number; 
        }
        public string ShowRemoveLicenceBySeriesNumber(Operation Op) { 
            return "Удалить лицензию " + Op.lic.series + ", " + Op.lic.number ;
        }
        public string ShowRemoveLicenceByContrInnKpp(Operation Op) { 
            return "Удалить все лицензии у контрагента с ИНН " + Op.cont.INN + " и КПП " + Op.cont.KPP; 
        }
        public string ShowChangeLicenceNumberBySeriesAndNumber(Operation Op) {
            /*По идее здесь еще должен быть серия*/
            return "Сменить номер лицензии " + Op.lic.series + ", " + Op.lic.number + " на " + Op.VarParam;
        }
        public string ShowChangeLicenceDateByNumber(Operation Op) { return ""; }
        public string ShowRemovingLicenceByInnKppEx(Operation Op) {
            return "Удалить все неиспользуемые лицензии у контрагента с ИНН " + Op.cont.INN + " и КПП " + Op.cont.KPP; 
        }
        public string ShowChangeKppByInnKpp(Operation Op) {
            return "Изменить КПП у контрагента с ИНН " + Op.cont.INN + " и КПП " + Op.cont.KPP + " на " + Op.VarParam; 
        }
        public string ShowRemoveContragentByInnKpp(Operation Op) {
            return "Удалить контрагента  с ИНН " + Op.cont.INN + " и КПП " + Op.cont.KPP; 
        }
        public string ShowRenameContragentByInnKpp(Operation Op)
        {
            return "Переименовать контрагента  с ИНН " + Op.cont.INN + " и КПП " + Op.cont.KPP + " на " + Op.VarParam;
        }
        public string ShowRenameContragentByInnKppRegion(Operation Op)
        {
            return "Переименовать всех контрагентов  с ИНН " + Op.cont.INN +  " с учетом региона, с приставкой " + Op.VarParam ;
        }
        public string ShowRemoveContragentById(Operation Op) { return ""; }

        /*Методы создания операций*/
        public Operation CreateRemoveLicenceByNumber(Contragent contr, Licence lic, string value) { 
            Operation op =  new Operation( (int) OpList.REMOVE_LICENCE_BY_NUMBER, new OperationView(ShowRemoveLicenceByNumber));
            CheckLicence(ref op, ref lic);
            return op;
        }
        public Operation CreateRemoveLicenceBySeriesNumber(Contragent contr, Licence lic, string value)
        {
            Operation op = new Operation((int)OpList.REMOVE_LICENCE_BY_SERIES_NUMBER, new OperationView(ShowRemoveLicenceBySeriesNumber));
            /*Здесь нас интересует только лицензия*/
            CheckLicence(ref op, ref lic);
            return op;
        }
        public Operation CreateRemoveLicenceByContrInnKpp(Contragent contr, Licence lic, string value)
        {
            Operation op = new Operation((int)OpList.REMOVE_LICENCE_BY_CONTR_INN_KPP, new OperationView(ShowRemoveLicenceByContrInnKpp));
            CheckContragent(ref op, ref contr);
            return op;
        }
        public Operation CreateChangeLicenceNumberBySeriesAndNumber(Contragent contr, Licence lic, string value)
        {
            Operation op = new Operation((int)OpList.CHANGE_LICENCE_NUMBER_BY_SERIES_AND_NUMBER, new OperationView(ShowChangeLicenceNumberBySeriesAndNumber));
            if (!CheckValue(value) ) return null;
            op.VarParam = value;
            CheckLicence(ref op, ref lic);
            return op;
        }
        public Operation CreateChangeLicenceDateByNumber(Contragent contr, Licence lic, string value)
        {
            Operation op = new Operation((int)OpList.CHANGE_LICENCE_DATE_BY_NUMBER, new OperationView(ShowChangeLicenceDateByNumber));
            return op;
        }
        public Operation CreateRemovingLicenceByInnKppEx(Contragent contr, Licence lic, string value)
        {
            Operation op = new Operation((int)OpList.REMOVING_LICENCE_BY_INN_KPP_EX, new OperationView(ShowRemovingLicenceByInnKppEx));
            CheckContragent(ref op, ref contr);
            return op;
        }
        public Operation CreateChangeKppByInnKpp(Contragent contr, Licence lic, string value)
        {
            Operation op = new Operation((int)OpList.CHANGE_KPP_BY_INN_KPP, new OperationView(ShowChangeKppByInnKpp));

            /*Здесь у нас новый КПП*/
            if (!CheckValue(value)) return null;
            op.VarParam = value;
            
            CheckContragent(ref op, ref contr);
            return op;
        }
        public Operation CreateRemoveContragentByInnKpp(Contragent contr, Licence lic, string value)
        {
            Operation op = new Operation((int)OpList.REMOVE_CONTRAGENT_BY_INN_KPP, new OperationView(ShowRemoveContragentByInnKpp));
            CheckContragent(ref op, ref contr);            
            return op;
        }
        public Operation CreateRenameContragentByInnKpp(Contragent contr, Licence lic, string value)
        {
            Operation op = new Operation((int)OpList.RENAME_CONTRAGENT_BY_INN_KPP, new OperationView(ShowRenameContragentByInnKpp));
            /*Название организации*/
            if (!CheckValue(value)) return null;
            op.VarParam = value;

            CheckContragent(ref op, ref contr);
            return op;
        }
        public Operation CreateRenameContragentByInnKppRegion(Contragent contr, Licence lic, string value)
        {
            Operation op = new Operation((int)OpList.RENAME_CONTRAGENT_BY_INN_KPP_REGION, new OperationView(ShowRenameContragentByInnKppRegion));
           
            /*Новое название организаций*/
            if (!CheckValue(value)) return null;
            op.VarParam = value;

            CheckContragent(ref op, ref contr);

            return op;
        }
        /* TODO: Нужно пометить как-нибудь, чтобы использовался один раз*/
        public Operation CreateRemoveContragentById(Contragent contr, Licence lic, string value)
        {
            Operation op = new Operation((int)OpList.RENAME_CONTRAGENT_BY_INN_KPP_REGION, new OperationView(ShowRenameContragentByInnKppRegion));
            CheckContragent(ref op, ref contr);
            return op;
        }
        /*Вспомогательные методы для создания*/
        /* Проверка на наличие лицензии. Этот и следующие методы можно вызывать 
         *только после присваивания произвольного значения*/
        private void CheckLicence(ref Operation op, ref Licence lic){
            
            if (lic == null)
                op = null;
            else
                op.lic = lic;            
        }
        /*Проверка на наличие контрагента*/
        private void CheckContragent(ref Operation op, ref Contragent cont)
        {

            if (cont == null)
                op = null;
            else
                op.cont = cont;
        }
        /*Проверка и того и того*/
        private void CheckBoth(ref Operation op, ref Contragent cont, ref Licence lic)
        {

            if (cont == null || lic == null)
                op = null;
            else
            {
                op.cont = cont;
                op.lic = lic;
            }
        }
        private bool CheckValue(string value)
        {
            if (value == "" || value == null)
                return false;
            return true;
        }

    }

    /*   Класс предназначен в основном для  изменения  контрагентов в базе, 
     * их  сериализацию, восстановление, изменение по определенным правилам
     * и копирование в другие базы.
     */
    class ContragentsEditor
    {
        String filename;

        List<Contragent> Contragents;
        List<Licence>    Licences;

        /*Тупо список операций*/
        Dictionary<int, OperationHandler> OperationHandlers;
        Dictionary<int, OperationCreate>  OperationFabrique;
        Dictionary<int, OperationView>    OperationsView;

        List<Operation>                     Operations;
   
        ContragentOperations cs;
        SqlCeWork            sql;


        public struct ListBoxItem
        {
            public int    operation;
            string view;

            public ListBoxItem(int o, string txt)
            {
                operation = o;
                view = txt;
            }

            public override string ToString()
            {
                return view;
            }
        };

        private List<ListBoxItem> OpListBox;

        public ContragentsEditor(string basename, string fname = "")
        {
            filename = fname;
            sql = new SqlCeWork(basename);

            OperationHandlers = new Dictionary<int,OperationHandler>();
            OperationFabrique = new Dictionary<int, OperationCreate>();
            OperationsView    = new Dictionary<int, OperationView>();

            Operations        = new List<Operation>();



            cs = new ContragentOperations(basename);
            cs.SetQueryFunctions(sql.query, sql.GetRow);

            Licences = new List<Licence>();
            Contragents = new List<Contragent>();
            SetData();

            OperationHandlers[(int)OpList.REMOVE_LICENCE_BY_NUMBER ]           = new OperationHandler(cs.RemoveLicenceByNumber);
            OperationHandlers[(int)OpList.REMOVE_LICENCE_BY_SERIES_NUMBER]     = new OperationHandler(cs.RemoveLicenceBySeriesNumber);
            OperationHandlers[(int)OpList.REMOVE_LICENCE_BY_CONTR_INN_KPP]     = new OperationHandler(cs.RemoveLicenceByContrInnKpp);
            OperationHandlers[(int)OpList.CHANGE_LICENCE_NUMBER_BY_SERIES_AND_NUMBER]     = new OperationHandler(cs.ChangeLicenceNumberBySeriesAndNumber);
            OperationHandlers[(int)OpList.CHANGE_LICENCE_DATE_BY_NUMBER]       = new OperationHandler(cs.ChangeLicenceDateByNumber);
            OperationHandlers[(int)OpList.REMOVING_LICENCE_BY_INN_KPP_EX]      = new OperationHandler(cs.RemovingLicenceByInnKppEx);
            OperationHandlers[(int)OpList.CHANGE_KPP_BY_INN_KPP]               = new OperationHandler(cs.ChangeKppByInnKpp);
            OperationHandlers[(int)OpList.REMOVE_CONTRAGENT_BY_INN_KPP]        = new OperationHandler(cs.RemoveContragentByInnKpp);
            OperationHandlers[(int)OpList.RENAME_CONTRAGENT_BY_INN_KPP]        = new OperationHandler(cs.RenameContragentByInnKpp);
            OperationHandlers[(int)OpList.RENAME_CONTRAGENT_BY_INN_KPP_REGION] = new OperationHandler(cs.RenameContragentByInnKppRegion);
            OperationHandlers[(int)OpList.REMOVE_CONTRAGENT_BY_ID]             = new OperationHandler(cs.RemoveContragentById);

            OperationFabrique[(int)OpList.REMOVE_LICENCE_BY_NUMBER]            = new OperationCreate(cs.CreateRemoveLicenceByNumber);
            OperationFabrique[(int)OpList.REMOVE_LICENCE_BY_SERIES_NUMBER]     = new OperationCreate(cs.CreateRemoveLicenceBySeriesNumber);
            OperationFabrique[(int)OpList.REMOVE_LICENCE_BY_CONTR_INN_KPP]     = new OperationCreate(cs.CreateRemoveLicenceByContrInnKpp);
            OperationFabrique[(int)OpList.CHANGE_LICENCE_NUMBER_BY_SERIES_AND_NUMBER]     = new OperationCreate(cs.CreateChangeLicenceNumberBySeriesAndNumber);
            OperationFabrique[(int)OpList.CHANGE_LICENCE_DATE_BY_NUMBER]       = new OperationCreate(cs.CreateChangeLicenceDateByNumber);
            OperationFabrique[(int)OpList.REMOVING_LICENCE_BY_INN_KPP_EX]      = new OperationCreate(cs.CreateRemovingLicenceByInnKppEx);
            OperationFabrique[(int)OpList.CHANGE_KPP_BY_INN_KPP]               = new OperationCreate(cs.CreateChangeKppByInnKpp);
            OperationFabrique[(int)OpList.REMOVE_CONTRAGENT_BY_INN_KPP]        = new OperationCreate(cs.CreateRemoveContragentByInnKpp);
            OperationFabrique[(int)OpList.RENAME_CONTRAGENT_BY_INN_KPP]        = new OperationCreate(cs.CreateRenameContragentByInnKpp);
            OperationFabrique[(int)OpList.RENAME_CONTRAGENT_BY_INN_KPP_REGION] = new OperationCreate(cs.CreateRenameContragentByInnKppRegion);
            OperationFabrique[(int)OpList.REMOVE_CONTRAGENT_BY_ID]             = new OperationCreate(cs.CreateRemoveContragentById);

            OperationsView[(int)OpList.REMOVE_LICENCE_BY_NUMBER]               = new OperationView(cs.ShowRemoveLicenceByNumber);
            OperationsView[(int)OpList.REMOVE_LICENCE_BY_SERIES_NUMBER]        = new OperationView(cs.ShowRemoveLicenceBySeriesNumber);
            OperationsView[(int)OpList.REMOVE_LICENCE_BY_CONTR_INN_KPP]        = new OperationView(cs.ShowRemoveLicenceByContrInnKpp);
            OperationsView[(int)OpList.CHANGE_LICENCE_NUMBER_BY_SERIES_AND_NUMBER]        = new OperationView(cs.ShowChangeLicenceNumberBySeriesAndNumber);
            OperationsView[(int)OpList.CHANGE_LICENCE_DATE_BY_NUMBER]          = new OperationView(cs.ShowChangeLicenceDateByNumber);
            OperationsView[(int)OpList.REMOVING_LICENCE_BY_INN_KPP_EX]         = new OperationView(cs.ShowRemovingLicenceByInnKppEx);
            OperationsView[(int)OpList.CHANGE_KPP_BY_INN_KPP]                  = new OperationView(cs.ShowChangeKppByInnKpp);
            OperationsView[(int)OpList.REMOVE_CONTRAGENT_BY_INN_KPP]           = new OperationView(cs.ShowRemoveContragentByInnKpp);
            OperationsView[(int)OpList.RENAME_CONTRAGENT_BY_INN_KPP]           = new OperationView(cs.ShowRenameContragentByInnKpp);
            OperationsView[(int)OpList.RENAME_CONTRAGENT_BY_INN_KPP_REGION]    = new OperationView(cs.ShowRenameContragentByInnKppRegion);
            OperationsView[(int)OpList.REMOVE_CONTRAGENT_BY_ID]                = new OperationView(cs.ShowRemoveContragentById);

            /*Здесь записываем все операции, что пойдут в ListBox*/
            OpListBox = new List<ListBoxItem> 
            { 
              new ListBoxItem((int) OpList.REMOVE_LICENCE_BY_NUMBER, "Удалить лицензию по номеру"),
              new ListBoxItem((int) OpList.REMOVE_LICENCE_BY_SERIES_NUMBER, "Удалить лицензию по серии и номеру"),
              new ListBoxItem((int) OpList.REMOVING_LICENCE_BY_INN_KPP_EX,"Удалить не используемые лицензии контрагента"),
              new ListBoxItem((int) OpList.CHANGE_LICENCE_NUMBER_BY_SERIES_AND_NUMBER,"Смена номера лицензии (по серии и номеру)"),
              new ListBoxItem((int) OpList.REMOVE_LICENCE_BY_CONTR_INN_KPP,"Удалить все лицензии контрагента"),
              new ListBoxItem((int) OpList.RENAME_CONTRAGENT_BY_INN_KPP_REGION, "Переименовать контрагента по региону в КПП"),
              new ListBoxItem((int) OpList.RENAME_CONTRAGENT_BY_INN_KPP, "Переименовать контрагента"),
              new ListBoxItem((int) OpList.CHANGE_KPP_BY_INN_KPP,"Сменить КПП у контрагента (по ИНН и КПП)"),
              new ListBoxItem((int) OpList.REMOVE_CONTRAGENT_BY_INN_KPP,"Удаление контагента (по ИНН и КПП)")
            };
        }

        /*Инициализация данных для текущей базы*/
        private void SetData()
        {
            /*TODO:Здесь не все поля для контрагентов. Не исключено добавление в будущем*/
             DataRow[] dr = sql.GetRow("SELECT id, INN, KPP, OrgName, RCode FROM wrk_Contragents ORDER BY INN");

            Contragents.Clear();
            /*Чтобы было очевидно*/
            int id = 0, INN = 1, KPP = 2, OrgName = 3, RCode = 4;
            for (int ix = 0; ix < dr.Length; ix++)
            {
                Contragent contr = new Contragent();

                contr.ContrId = (Int32)dr[ix][id];
                contr.INN     = dr[ix][INN].ToString();
                contr.KPP     = dr[ix][KPP].ToString();
                contr.OrgName = dr[ix][OrgName].ToString();
                contr.RCode   = dr[ix][RCode].ToString();

                Contragents.Add(contr);
            }

            DataRow[] dl = sql.GetRow("SELECT id, ref_contr_id, series,number,dateBegin,dateEnd,ref_licTypeId FROM  wrk_contr_licenses");

            Licences.Clear();
            /*также обозначим поля*/
            int ref_contr_id = 1, series = 2, number = 3, dateBegin = 4, dateEnd = 5, type = 6;
            for (int ix = 0; ix < dl.Length; ix++)
            {
                Licence lic   = new Licence();

                lic.LicId     = (int) dl[ix][id];
                lic.ContrId   = (int) dl [ix][ref_contr_id];
                lic.series    = dl[ix][series].ToString();
                lic.number    = dl[ix][number].ToString();
                lic.dateBegin = dl[ix][dateBegin].ToString();
                lic.dateEnd   = dl[ix][dateEnd].ToString();
                lic.typeid    = (int) dl[ix][type];
                

                Licences.Add(lic);
            }

        }

        private void Serialization()
        {
            if (filename == "")
                return;
        }

        private void Reading()
        {
            if (filename == "")
                return;

        }

        public void GetLicenceByContrId(int id, ref ListBox Box)
        {
            /*Новый временный список*/
            List<Licence> LicList = new List<Licence>();
            foreach (Licence lic in Licences)
            {
                if (lic.ContrId == id)
                {
                    LicList.Add(lic);
                }
            }

            BoxAddingWithClearing<Licence>(ref LicList, ref Box);
        }

        public void GetOperations(ref ComboBox box)
        {
            BoxAddingWithClearing<ListBoxItem>(ref OpListBox, ref box);
        }
        public void GetOperations(ref ListBox box)
        {
            BoxAddingWithClearing<Operation>(ref Operations, ref box);
        }

        public void GetContragents(ref ListBox Box)
        {
            BoxAddingWithClearing<Contragent>(ref Contragents, ref Box);
        }

        public void ContragentsByInnInListBox(string inn, ref System.Windows.Forms.ListBox list)
        {
            List<Contragent> ContragentList = new List<Contragent>();
            
            /*Тупо перебираем для поиска*/
            foreach (Contragent contr in Contragents)
            {
                if (contr.INN == inn)
                {
                    ContragentList.Add(contr);
                }
            }

            BoxAddingWithClearing<Contragent >(ref ContragentList, ref list);
        }

        /*Добавление с удалением элементов*/
        private void BoxAddingWithClearing<T>(ref List<T> list, ref System.Windows.Forms.ListBox box)
        {
            box.Items.Clear();
            BoxAdding<T>(ref list, ref  box);
        }
        private void BoxAddingWithClearing<T>(ref List<T> list, ref System.Windows.Forms.ComboBox box)
        {
            box.Items.Clear();
            BoxAdding<T>(ref list, ref  box);
        }

        /*Просто добавление элементов*/
        private void BoxAdding<T>(ref List<T> list, ref System.Windows.Forms.ListBox box)
        {
            foreach (T item in list)
            {
                box.Items.Add(item);
            }
        }
        private void BoxAdding<T>(ref List<T> list, ref System.Windows.Forms.ComboBox box)
        {
            foreach (T item in list)
            {
                box.Items.Add(item);
            }
        }

        public void CreateOperation(Contragent cont, Licence lic, int id, string value)
        {
            Operation op = OperationFabrique[id](cont, lic,  value);

            /*Проверка на ошибки*/
            if (op != null)
                Operations.Add(op);
        }

        /* TODO: Сделать, чтобы такой код запускался для всех баз. Точнее смена базы и выполнение списка*/
        public void RunOperations(){

            foreach (Operation op in Operations)
            {
                /*Вот такой незамысловатый код выполняет все что нужно*/
                OperationHandlers[op.OpId](op);
            }

            /*Принимаем вновь измененные данные*/
            SetData();
        }
        
        
        public List<ListBoxItem> GetListBoxItems()
        {
            return OpListBox;
        }

        

    }
}
