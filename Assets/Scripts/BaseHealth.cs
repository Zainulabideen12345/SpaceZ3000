namespace DefaultNamespace
{
    public class BaseHealth
    {
        private int _initialHeath;
        private int _currentHealth;

        public int CurrentHealth => _currentHealth;

        public BaseHealth(int initialHeath)
        {
            _initialHeath = initialHeath;
            _currentHealth = initialHeath;
        }

        public bool IsHealthDepleted() => _currentHealth <= 0;
        public bool IsFullHealth() => _initialHeath == _currentHealth;

        public virtual int TakeDamage(int damage)
        {
            if (_currentHealth > damage)
            {
                _currentHealth -= damage;
                return 0;
            }
            var damageLeftover = damage - _currentHealth;
            _currentHealth = 0;
            return damageLeftover;
        }

        public void AddHealth(int health)
        {
            _currentHealth += health;
        }
    }
}