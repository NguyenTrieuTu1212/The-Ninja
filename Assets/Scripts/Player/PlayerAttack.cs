using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    private EnermyBrain enermyTarget;
    private Player player;

    private PlayerAnimations playerAnimations;
    private PlayerMovement playerMovement;
    private PlayerMana playerMana;

    private Transform currentAttackPositon;
    private float currentAttackRotation;
    private List<Transform> listPointAttack = new List<Transform>();

    [SerializeField] private TextMeshProUGUI textAlert_TMP;
    [SerializeField] private Canvas panelDialog;
    [SerializeField] public Weapon initWeapon;
    public Weapon CurrentWeapon { get; private set; }
    private bool isAttacking = false;
    private bool isDisplay = false;

    
    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
        playerMovement = GetComponent<PlayerMovement>();
        playerMana = GetComponent<PlayerMana>();
        player = GetComponent<Player>();
        FindPointsAttacking();
    }

    private void Start()
    {
        if (initWeapon == null) return;
        WeaponManager.Instance.EquipItem(initWeapon);
    }

    private void Update()
    {
        GetPosistionFire();
        if (Input.GetKeyDown(KeyCode.Space)) Attack();
        
    }


    private void FindPointsAttacking()
    {
        Transform attackPoints = transform.Find("Attack_Points");
        foreach (Transform attackPoint in attackPoints) listPointAttack.Add(attackPoint);
    }

    public void Attack()
    {
        if (enermyTarget == null || isAttacking) return;
        if (player.Stats.mana < CurrentWeapon.RequireMana)
        {
            textAlert_TMP.text = "Not enough mana \n to use weapons !!!!!";
            StartCoroutine(WatingDisplayDialogNotification());
            return;
        }
        else StartCoroutine(WaitingAttacking());
        
    }



    IEnumerator WatingDisplayDialogNotification()
    {
        isDisplay = true;
        AudioManager.Instance.PlaySFX("Alert");
        panelDialog.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        panelDialog.gameObject.SetActive(false);
        isDisplay = false;
    }



    IEnumerator WaitingAttacking()
    {
        isAttacking = true;
        if (currentAttackPositon != null)
        {
            if (player.Stats.mana < CurrentWeapon.RequireMana)
            {
                if(!isDisplay) StartCoroutine(WatingDisplayDialogNotification());
                isAttacking = false;
                yield break;
            }
            // durability wepon
            CurrentWeapon.durability -= CurrentWeapon.offset;
            Debug.Log("Weapon durability is " + CurrentWeapon.durability);

            BulletShoot bullet = BulletManager.Instance.TakeBullet(CurrentWeapon.nameBullet, currentAttackPositon.position, currentAttackRotation);
            bullet.direction = Vector3.up;
            bullet.damage = GetDamageCritical();
            playerMana.UsedMana(CurrentWeapon.RequireMana);
        }
        playerAnimations.SetAttacking(true);
        yield return new WaitForSeconds(0.5f);
        playerAnimations.SetAttacking(false);
        yield return new WaitForSeconds(CurrentWeapon.requireTime - 0.5f);
        isAttacking = false;
    }

    public void EquipWeapon(Weapon weapon)
    {
        CurrentWeapon = weapon;
        player.Stats.totalDamage += player.Stats.baseDamage + CurrentWeapon.damage;
    }


    private float GetDamageCritical()
    {
        float damage = player.Stats.baseDamage;
        damage += CurrentWeapon.damage;
        float randomDamage = Random.Range(0f, 100f);
        if(randomDamage <= player.Stats.criticalChance)
        {
            damage += damage * (player.Stats.criticalDamage/100f);
        }
        return damage;
    }

    private void GetPosistionFire()
    {
        Vector2 currentPositionPlayer = playerMovement.MoveDirection;
        if (currentPositionPlayer != Vector2.zero)
        {
            if (Mathf.Abs(currentPositionPlayer.x) > Mathf.Abs(currentPositionPlayer.y))
            {
                // X�c �?nh h�?ng ngang
                currentAttackPositon = (currentPositionPlayer.x < 0f) ? listPointAttack[0] : listPointAttack[1];
                currentAttackRotation = (currentPositionPlayer.x < 0f) ? 90f : -90f;
            }
            else
            {
                // X�c �?nh h�?ng d?c
                currentAttackPositon = (currentPositionPlayer.y > 0f) ? listPointAttack[2] : listPointAttack[3];
                currentAttackRotation = (currentPositionPlayer.y > 0f) ? 0f : -180f;
            }
        }
    }

    private void OnSelectedToAttackCallBack(EnermyBrain enermySelected)
    {
        enermyTarget = enermySelected;
    }

    private void NoOnSelectedToAttackCallBack()
    {
        enermyTarget = null;
    }

    private void OnEnable()
    {
        SelectorManager.OnSelectedEnermy += OnSelectedToAttackCallBack;
        SelectorManager.NoOnSelectedEnermy += NoOnSelectedToAttackCallBack;
    }


    private void OnDisable()
    {
        SelectorManager.OnSelectedEnermy -= OnSelectedToAttackCallBack;
        SelectorManager.NoOnSelectedEnermy -= NoOnSelectedToAttackCallBack;
    }
}
