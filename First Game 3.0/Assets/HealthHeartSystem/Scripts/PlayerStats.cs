/*
 *  Author: ariel oliveira [o.arielg@gmail.com]
 */

using UnityEngine;

public class PlayerStats : MonoBehaviour {
    [SerializeField]
    private float health, maxHealth, maxTotalHealth;

    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    private static PlayerStats instance;

    public void Heal(float health) {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg) {
        health -= dmg;
        ClampHealth();
    }

    public void AddHealth() {
        if (maxHealth < maxTotalHealth) {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }
    }

    void ClampHealth() {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    public static PlayerStats Instance {
        get {
            if (instance == null)
                instance = FindObjectOfType<PlayerStats>();
            return instance;
        }
    }
}