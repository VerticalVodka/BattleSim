namespace BattleSim.Model
{
    public static class ShipValues
    {
        private const int AMOUNT_SHIPS = 18;

        public static readonly string[] Names = new string[AMOUNT_SHIPS]
        {
            "Scout",
            "Frigate",
            "Crusader",
            "Athmos",
            "BM",
            "Blondie",
            "Esaki L",
            "Vici",
            "Hess",
            "Colo",
            "Nano Probe",
            "Cargo",
            "Recycler",
            "Heimdall",
            "Missle Launcher",
            "Magnetic Field Generator",
            "Force Field",
            "Plasma Coil"
        };

        public static readonly int[] BaseHP = new int[AMOUNT_SHIPS]
        {
            600,
            980,
            5000,
            2000,
            4500,
            8000,
            2000,
            5000,
            16000,
            5000,
            1,
            3500,
            2400,
            17000,
            0,
            0,
            0,
            0
        };

        public static readonly int[] BaseDamage = new int[AMOUNT_SHIPS]
        {
            200,
            500,
            300,
            1500,
            3000,
            600,
            1200,
            500,
            6000,
            0,
            0,
            0,
            0,
            5500,
            0,
            0,
            0,
            0
        };

        public static readonly int[] BaseShield = new int[AMOUNT_SHIPS]
        {
            5,
            10,
            150,
            40,
            400,
            100,
            50,
            30,
            850,
            10,
            0,
            7,
            20,
            450,
            0,
            0,
            0,
            0
        };

        public static readonly int[] BaseRocket = new int[AMOUNT_SHIPS]
        {
            0,
            0,
            800,
            0,
            200,
            5000,
            0,
            100,
            2500,
            0,
            0,
            0,
            0,
            3500,
            0,
            0,
            0,
            0
        };

        public static readonly int[] BaseDodge = new int[AMOUNT_SHIPS]
        {
            30,
            40,
            10,
            20,
            13,
            10,
            30,
            5,
            10,
            0,
            0,
            0,
            0,
            5,
            0,
            0,
            0,
            0
        };

        public static readonly int[] BaseAim = new int[AMOUNT_SHIPS]
        {
            25,
            35,
            10,
            15,
            20,
            15,
            70,
            10,
            40,
            0,
            0,
            0,
            0,
            50,
            0,
            0,
            0,
            0
        };

        public static readonly int[] BaseSize = new int[AMOUNT_SHIPS]
        {
            1,
            2,
            6,
            5,
            10,
            12,
            3,
            12,
            20,
            7,
            1,
            2,
            3,
            15,
            0,
            0,
            0,
            0
        };

        public static readonly int[][] ShipsAffected = new int[AMOUNT_SHIPS][]
        {
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27},
            new[] {0,1,2,3,4,27}
        };
    }
}