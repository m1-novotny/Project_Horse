using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class board : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject white;
    public GameObject black;
    public GameObject green;
    public GameObject player;
    public int score;
    public string[] markerarray;
    public int markers;
    int tilesize;
    public bool done = false;
    int newx;
    int newy;
    float timer;
    public bool move;
    public GameObject falling;
    public bool rotate;
    public int visited;
    public int mode;
    Quaternion target;
    void Start()
    {
        timer = 0;
        move = false;
        newx = 3;
        newy = 0;
        tilesize = 3;
        score = 1;
        visited = 1;
        mode = PlayerPrefs.GetInt("mode");
        GameObject tile;
        int x;
        int y;
        string vysledek;
        if (mode != 3)
        {
            for (var i = 0; i < 64; i++)
            {
                x = i / 8;
                y = i % 8;
                if ((i - x) % 2 == 0)
                {
                    tile = Instantiate(white, new Vector3(x * tilesize, 0, y * tilesize), Quaternion.identity) as GameObject;

                }
                else
                {
                    tile = Instantiate(black, new Vector3(x * tilesize, 0, y * tilesize), Quaternion.identity) as GameObject;

                }
                vysledek = x.ToString() + y.ToString();
                tile.name = vysledek;
            }
            if (mode == 2)
            {
                x = Random.Range(0,8);
                y = Random.Range(0,8);
                player.transform.position = new Vector3(x * tilesize, player.transform.position.y, y * tilesize);
             }

        }
        ShowMarkers();

    }
    void ShowMarkers()
    {
        done = false;
        markers = 0;
        int x = (int)(player.transform.position.x)/tilesize;
        int y = (int)(player.transform.position.z)/tilesize;
        string jmeno;
        GameObject tile;
        GameObject marker;
        int[,] moznosti = new int[8,2] { {x+2,y+1}, {x+2,y-1}, {x-2,y+1}, {x-2,y-1}, {x+1,y+2}, {x+1,y-2}, {x-1,y+2}, {x-1,y-2} };

        markerarray = new string[8];
        for (int i = 0; i < 8; i++)
        
            
            {
                jmeno = moznosti[i,0].ToString() + moznosti[i,1].ToString();
                tile = GameObject.Find(jmeno);
                if ((tile != null)&&(tile.transform.position.y==0))
                {
                    marker = Instantiate(green, new Vector3(moznosti[i,0]*tilesize, 0, moznosti[i,1]*tilesize), Quaternion.identity) as GameObject;
                    marker.name = "G" + jmeno;
                    markerarray[i] = "G" + jmeno;
                    markers++;
                }
            }
        done = true;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)&&(hit.transform.name[0]=='G')){
                int x = (int)(player.transform.position.x) / tilesize;
                int y = (int)(player.transform.position.z) / tilesize;
                newx = (int)hit.transform.position.x;
                newy = (int)hit.transform.position.z;
                var direction = (hit.transform.position - player.transform.position).normalized;
                target = Quaternion.LookRotation(direction);
                string jmeno = x.ToString() + y.ToString();
                GameObject tile;
                tile = GameObject.Find(jmeno);
                falling = tile;
                rotate = true;
                for (int i = 0; i < 8; i++)
                {
                    tile = GameObject.Find(markerarray[i]);
                    Destroy(tile);
                }
                score++;
                visited++;


            }
        }
        if (rotate==true)
        {
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, target, 100f * Time.deltaTime);
            if (Quaternion.Angle(target, player.transform.rotation)<1)
            {
                move = true;
                rotate = false;
            }
        }
        if (move == true)
        {
            timer = timer + Time.deltaTime;
            var position = player.transform.position;
            var target = new Vector3(newx, player.transform.position.y, newy);
            
            var position2 = falling.transform.position;
            var target2 = new Vector3(falling.transform.position.x, -50, falling.transform.position.z);
            if (timer > 0.7)
            {
                player.transform.position = Vector3.MoveTowards(position, target, 8 * Time.deltaTime);
            }
                if (timer>1.7)
            {
                falling.transform.position = Vector3.MoveTowards(position2, target2, 20 * (Time.deltaTime*timer));
            }

            if ((Vector3.Distance(position2, target2)+Vector3.Distance(position,target)<0.002f))
            {
                player.transform.position = target;
                move = false;
                timer = 0;
                ShowMarkers();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

    }
}
