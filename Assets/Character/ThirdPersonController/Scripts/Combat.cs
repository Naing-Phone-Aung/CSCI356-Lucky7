using Project.End;
using UnityEngine;
using UnityEngine.UI;

namespace StarterAssets
{
    public class Combat : MonoBehaviour
    {
        public int maxPlayerHealth = 100;
        public int currentHealth;

        public Image HealthBar;
        float lerpSpeed;

        private Animator _animator;
        private StarterAssetsInputs _input;
        private WeaponManager _weaponManager;
        private bool _hasAnimator;
        private bool _isAttacking = false;

        // Animation ID
        private int _animIDPunch;
        private int _animIDSword;

        private void Start()
        {
            _hasAnimator = TryGetComponent(out _animator);
            _input = GetComponent<StarterAssetsInputs>();
            _weaponManager = GetComponent<WeaponManager>();

            currentHealth = maxPlayerHealth;

            AssignAnimationIDs();
        }

        private void Update()
        {
            if (currentHealth > maxPlayerHealth) currentHealth = maxPlayerHealth;

            lerpSpeed = 3f * Time.deltaTime;

            HealthBarFiller();
            ColorChanger();

            HandleAttacking();
        }

        private void HealthBarFiller()
        {
            // Calculate the health percentage and update the health bar fill
            float healthPercentage = (float)currentHealth / maxPlayerHealth;
            HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount, healthPercentage, lerpSpeed);
        }

        private void ColorChanger()
        {
            // Change color from green to yellow to red based on the health percentage
            float healthPercentage = (float)currentHealth / maxPlayerHealth;
            if (healthPercentage > 0.5f)
            {
                // Health > 50%, lerp from yellow to green
                HealthBar.color = Color.Lerp(Color.yellow, Color.green, (healthPercentage - 0.5f) * 2);
            }
            else
            {
                // Health <= 50%, lerp from red to yellow
                HealthBar.color = Color.Lerp(Color.red, Color.yellow, healthPercentage * 2);
            }
        }

        private void AssignAnimationIDs()
        {
            _animIDPunch = Animator.StringToHash("Attack");
        }

        private void HandleAttacking()
        {
            if (_input.attack > 0 && !_isAttacking)
            {
                if (_hasAnimator)
                {
                    // Determine attack type based on equipped weapon
                    if (_weaponManager.equippedWeapon == null)
                    {
                        // No weapon equipped, punch (set attack type 1)
                        _animator.SetInteger("Attack", 1);
                    }
                    else if (_weaponManager.equippedWeapon.weaponName == "Sword")
                    {
                        // Sword equipped, sword slash (set attack type 2)
                        _animator.SetInteger("Attack", 2);
                    }
                    else if (_weaponManager.equippedWeapon.weaponName == "Axe")
                    {
                        // Sword equipped, sword slash (set attack type 2)
                        _animator.SetInteger("Attack", 3);
                    }
                    else if (_weaponManager.equippedWeapon.weaponName == "ThorAxe")
                    {
                        // Sword equipped, sword slash (set attack type 2)
                        _animator.SetInteger("Attack", 3);
                    }
                    _isAttacking = true;
                    _input.attack = 0; // Reset attack input
                }
            }
            else if (_isAttacking)
            {
                // Check if the current attack animation is still playing
                if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    // If the animation is still playing, do nothing
                    return;
                }
                else
                {
                    // Animation has finished, deal damage to the enemy
                    //DealDamage();

                    // Reset attack state
                    if (_hasAnimator)
                    {
                        _animator.SetInteger("Attack", 0); // Reset attack type
                        _isAttacking = false;
                    }
                }
            }
        }

        /* private void DealDamage()
        {
            // Get the damage value from the equipped weapon or default punch damage
            int damage = _weaponManager.equippedWeapon != null ? _weaponManager.equippedWeapon.damage : 10; // Default punch damage

            // Detect enemies in range (this can be done using raycasts, triggers, or other methods)
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position + transform.forward, 1.5f);
            foreach (Collider enemyCollider in hitEnemies)
            {
                Enemy enemy = enemyCollider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
        } */
    }
}
