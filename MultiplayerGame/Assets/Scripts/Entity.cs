﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Entity : MonoBehaviour {

	public int healthCurrent = 10;
	public int healthMax = 10;
	public bool isDead = false;

	public event Action eventTakeDamage;
	public event Action eventTakeHeal;
	public event Action eventDie;
	public event Action eventRespawn;

	public void TakeDamage (int damage) {
		healthCurrent = (int)Mathf.Clamp(healthCurrent - damage, 0, healthMax);
		if (eventTakeDamage != null) {
			eventTakeDamage();
		}

		if (healthCurrent == 0) {
			Die();
		}
	}

	public void TakeHeal (int heal) {
		healthCurrent = (int)Mathf.Clamp(healthCurrent + heal, 0, healthMax);
		if (eventTakeHeal != null) {
			eventTakeHeal();
		}

		if (healthCurrent == 0) {
			Die();
		}
	}

	public void Die () {
		if (isDead == false) {
			isDead = true;
			if (eventDie != null) {
				eventDie();
			}
		}
	}

	public void Respawn() {
		if (isDead == true) {
			isDead = false;
			if (eventRespawn != null) {
				eventRespawn();
			}
		}
	}

}
