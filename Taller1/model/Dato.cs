using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller1.model
{
    class Dato
    {
        //Attributtes

        private String region;
        private String codeD;
        private String department;
        private String codeM;
        private String municipio;

        //

        public Dato(String region, String codeD, String department, String codeM, String municipio)
        {
            this.region = region;
            this.codeD = codeD;
            this.department = department;
            this.codeM = codeM;
            this.municipio = municipio;

        }

        public String getRegion()
        {
            return region;
        }

        public void setRegion(String region)
        {
            this.region = region;
        }

        public String getCodeD()
        {
            return codeD;
        }

        public void setCodeD(String codeD)
        {
            this.codeD = codeD;
        }

        public String getDepartment()
        {
            return department;
        }

        public void setDepartment(String department)
        {
            this.department = department;
        }

        public String getCodeM()
        {
            return codeM;
        }

        public void setCodeM(String codeM)
        {
            this.codeM = codeM;
        }

        public String getMunicipio()
        {
            return municipio;
        }

        public void setMunicipio(String municipio)
        {
            this.municipio = municipio;
        }
    }


}
