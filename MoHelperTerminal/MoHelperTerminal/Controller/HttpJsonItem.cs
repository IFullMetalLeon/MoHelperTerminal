using System;
using System.Collections.Generic;
using System.Text;

namespace MoHelperTerminal.Controller
{
    public class HttpJsonItem
    {
        public class PostIODocResponce
        {
            public string type { get; set; }
            public string nommodif { get; set; }
            public string pack_quant { get; set; }
			public string comment { get; set; }
			public string doc_rn { get; set; }
			public string box_rn { get; set; }
        }
        public class GetIODocHeadResponce
        {
            public string TC_RN { get; set; }
            public string DOC_NUM { get; set; }
            public string DOC_DATE { get; set; }
        }

        public class GetIODocSpecResponce
        {
            public string TC_RN { get; set; }
            public string NOMODIF { get; set; }
            public string MODIF_NAME { get; set; }
            public string QUANT_TCS { get; set; }
            public string QUANT_FACT { get; set; }           
        }

        public class GetIODocBoxResponce
        {
            public string RN { get; set; }
            public string TC_RN { get; set; }
            public string BOX_NUM { get; set; }
            public string MODIF_NAME { get; set; }
            public string BOX_QUANT { get; set; }
            public string FACT_QUANT { get; set; }
        }

        public class GetIODocMarkResponce
        {
            public string RN { get; set; }
            public string BOX_RN { get; set; }     
            public string TC_RN { get; set; }
            public string PREF { get; set; }
            public string NUMB { get; set; }
            public string IS_SCANED { get; set; }
            public string MODIF_NAME { get; set; }
        }
    }
}
