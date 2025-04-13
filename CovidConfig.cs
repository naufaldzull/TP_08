using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_103022300021
{
    class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        private const string configFile = "covid_config.json";

        public static CovidConfig Load()
        {
            if (!File.Exists(configFile))
            {
                var defaultConfig = new CovidConfig
                {
                    satuan_suhu = "celcius",
                    batas_hari_deman = 14,
                    pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                    pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
                };
                File.WriteAllText(configFile, JsonSerializer.Serialize(defaultConfig));
                return defaultConfig;
            }

            string json = File.ReadAllText(configFile);
            return JsonSerializer.Deserialize<CovidConfig>(json);
        }

        public void UbahSatuan()
        {
            satuan_suhu = satuan_suhu == "celcius" ? "fahrenheit" : "celcius";
            File.WriteAllText(configFile, JsonSerializer.Serialize(this));
        }
    }
}
