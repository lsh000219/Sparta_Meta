# Sparta_Meta

기본 
- wasd로 이동
- 마우스 클릭으로 공격
- 왼쪽 위에 골드표시


중앙 NPC
- 노인(주요 코드 - OldManNPC.CS)
  버튼을 누르면 상하좌우의 오브젝트에 대해 말함(자세히 설명 X)
- 천사(ScoreBoard.CS)
  미니게임 두 가지의 최고점수를 보여줌


위쪽(GameManager.CS, PlayerController.CS, EnemyManager.CS)
- 고블린 세마리가 기사를 괴롭히고 있음, 다가가면 UI가 보임
- 시작을 누르면 TopDown 슈팅게임 시작(강의에서 만든)
- 플레이어 사망시 Wave의 숫자만큼 골드 획득
- 이후 재도전 또는 나가기 가능


오른쪽(ExitTheDungeon.CS, Scripts/ExitTheDungeon 내 스크립트들)
- 계단 모양 바닥이 있음, 다가가면 UI가 보임
- 시작시 씬이 넘어가고 플레이어 캐릭터가 달리기 시작, 장애물을 피해 문까지 도달하면 Stage가 하나씩 오름
- 장애물에 닿으면 게임 오버, Stage만큼 골드를 받음
- 이후 재도전 또는 나가기 가능


왼쪽(RidingShopNPC, RidingBoxNPC)
- 새부리 가면에게 다가가면 탈 것을 구매 가능(5가지, 가격은 다 100 골드로 통일)
- 구매 후 왼쪽 위에있는 상자에 가면 장착 가능(장착 해제도 가능)
- 탈 것에게 달린 속도 능력치에 따라 플레이어의 속도가 바뀜
- 스프라이트도 붙지만 마우스에 따라 스프라이트가 오른쪽, 왼쪽으로 안바뀌게 함(정신 없어서)


아래쪽(SkinShopNPC, SkinBoxNPC)
- 마법사에게 다가가면 플레이어 스킨을 구매 가능(2가지, 가격은 다 100 골드로 통일)
- 구매 후 왼쪽 위에있는 상자에 가면 장착 가능
- 따로 바뀌는 스텟은 없음


-------------------------------------------------------------

Basics
- Move with WASD
- Click the mouse to attack
- Gold amount is shown at the top-left corner

Center NPCs
- Old Man (main script: OldManNPC.cs)
  Talks about the objects in four directions when a button is pressed (not in detail)

- Angel (ScoreBoard.cs)
  Shows the highest scores from two mini-games


Top Area (GameManager.cs, PlayerController.cs, EnemyManager.cs)
- Three goblins are bothering a knight; UI appears when you approach
- Press Start to begin a TopDown shooting game (from lecture project)
- When the player dies, gain gold equal to the current wave number
- Can retry or exit after that


Right Area (ExitTheDungeon.cs and scripts in Scripts/ExitTheDungeon)
- There is a staircase-shaped floor; UI appears when you approach
- Upon starting, the scene changes and the player starts running
- Avoid obstacles and reach the door to increase the stage count
- Touching obstacles results in game over; gold is rewarded based on stage
- Can retry or exit afterward


Left Area (RidingShopNPC.cs, RidingBoxNPC.cs)
- Approach the bird-masked NPC to purchase a mount
- 5 types available, each costs 100 gold
- After purchase, go to the box at the top-left to equip or unequip
- Player speed changes based on the mount’s speed stat
- Sprite is attached, but does not flip left/right based on mouse direction (to avoid confusion)


Bottom Area (SkinShopNPC.cs, SkinBoxNPC.cs)
- Approach the wizard to buy player skins
- 2 types available, each costs 100 gold
- After purchase, go to the box at the top-left to equip
- Skins are purely cosmetic; no stat changes

