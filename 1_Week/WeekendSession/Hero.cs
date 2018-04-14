using System.Collections.Generic;

namespace WeekendSession
{
    public interface IDamageable
    {
        int Health {get;set;}
        bool TakeDamage(int dmg);
    }
    public class Hero
    {
        public string Name;
        public int Health;
        public Hero(string name)
        {
            Name = name;
            Health = 100;
        }
        // returns true if enemy destroyed
        public void Attack(IDamageable target, int dmg)
        {
            target.TakeDamage(dmg);
        }
        public void AOEAttack(IEnumerable<IDamageable> targets, int dmg)
        {
            foreach(IDamageable target in targets)
                target.TakeDamage(dmg);
        }
    }
    public class Building : IDamageable
    {
        private int _initalHealth = 500;
        public int Health {get;set;}
        public Building()
        {
            Health = _initalHealth;
        }
        public bool TakeDamage(int dmg)
        {
            // take double damage if less than 25% health depleted
            if(Health/_initalHealth < .25)
                dmg = dmg * 2;
            
            if((Health - dmg) < 1)
            {
                Health = 0;
                return true;
            }
            Health -= dmg;
            return false;
        }
    }
    public class Enemy : IDamageable
    {
        public string Name;
        public int Health {get;set;}
        public bool TakeDamage(int dmg)
        {
            if((Health - dmg) < 1)
            {
                Health = 0;
                return true;
            }
            Health -= dmg;
            return false;
        } 
        public List<string> Powers;
        public Enemy(string name)
        {
            Name = name;
            Health = 100;
            Powers = new List<string>();
        }
    }
}
