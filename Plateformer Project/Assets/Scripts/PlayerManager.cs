using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private Transform spawnTransform;     // Check Piont, Save Point 시작 위치 변경해주는 기능

    private PlayerController playerController;             // playerController에서 빠진 컴포넌트를 
    public PlayerCam playerCam;                           // playerCam 클래스에 접근. RespawnPlayer에서 playerCam에 접근할 수 있게 코드를 작성해보세요.

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        RespawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayer();
        }

        // 만약 player 변수가 null이면 Respawn해라.
        if (player == null)
        {
            RespawnPlayer();
        }
    }

    public void RespawnPlayer()
    {
        player = Instantiate(PlayerPrefab, spawnTransform.position, Quaternion.identity);

        playerController = player.GetComponent<PlayerController>(); // 다른 코드에 접근 하는 방법



        playerCam.playerTransform = player.transform;
        
        playerCam.ResetCameraPosition();
        playerCam.Setoffset();
    }
}
