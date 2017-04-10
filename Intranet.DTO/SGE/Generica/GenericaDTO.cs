using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.DTO.Global;

namespace Intranet.DTO.SGE
{
    public class GenericaDTO : EventArgs
    {
        public int IdGenerica { get; set; }

        public eTabla Tabla
        {
            get;
            set;
        }


        private string mA1;
        public string A1
        {
            get
            {
                if (mA1 == null)
                {
                    return "";
                }
                else
                {
                    return mA1;
                }

            }
            set { mA1 = value; }
        }


        private string mA2;
        public string A2
        {
            get
            {
                if (mA2 == null)
                {
                    return "";
                }
                else
                {
                    return mA2;
                }

            }
            set { mA2 = value; }
        }


        private string mA3;
        public string A3
        {
            get
            {
                if (mA3 == null)
                {
                    return "";
                }
                else
                {
                    return mA3;
                }

            }
            set { mA3 = value; }
        }

        private string mA4;
        public string A4
        {
            get
            {
                if (mA4 == null)
                {
                    return "";
                }
                else
                {
                    return mA4;
                }

            }
            set { mA4 = value; }
        }

    }
}