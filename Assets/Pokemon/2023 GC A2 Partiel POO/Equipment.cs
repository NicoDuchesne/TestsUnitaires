
namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Défintion simple d'un équipement apportant des boost de stats
    /// </summary>
    public enum SpecialEffect { NONE, RAZORCLAW } /// effet spécial que peu avoir l'équipement
    public class Equipment
    {
        /// <summary>
        /// Vie bonus
        /// </summary>
        int _bonusHealth;
        /// <summary>
        /// Atatque bonus
        /// </summary>
        int _bonusAttack;
        /// <summary>
        /// Defense bonus
        /// </summary>
        int _bonusDefense;
        /// <summary>
        /// Vitesse bonus
        /// </summary>
        int _bonusSpeed;
        /// <summary>
        /// effet special
        /// </summary>
        SpecialEffect _specialEffect;

        public Equipment(int bonusHealth, int bonusAttack, int bonusDefense, int bonusSpeed, SpecialEffect specialEffect = SpecialEffect.NONE)
        {
            _bonusHealth = bonusHealth;
            _bonusAttack = bonusAttack;
            _bonusDefense = bonusDefense;
            _bonusSpeed = bonusSpeed;
            if (specialEffect != SpecialEffect.NONE) {
                _specialEffect = specialEffect;
            } 
        }

        public int BonusHealth { get => _bonusHealth; protected set => _bonusHealth = value; }
        public int BonusAttack { get => _bonusAttack; protected set => _bonusAttack = value; }
        public int BonusDefense { get => _bonusDefense; protected set => _bonusDefense = value; }
        public int BonusSpeed { get => _bonusSpeed; protected set => _bonusSpeed = value; }
        public SpecialEffect SpecialEffect { get => _specialEffect; protected set => _specialEffect = value; }

    }
}
