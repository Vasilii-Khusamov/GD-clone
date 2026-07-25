using UnityEngine;

public enum GameMode
{
    Cube,
    Ship,
    Unknown
}

public class GameModeSwitcher
{
    public static void Switch(GameObject hero, GameMode gameMode)
    {
        Rigidbody2D rb = hero.GetComponent<Rigidbody2D>();
        switch (gameMode)
        {
            case GameMode.Cube:
                disableEverything(hero);
                ImpulseMover impulseMover = hero.GetComponent<ImpulseMover>();
                if (impulseMover != null)
                {
                    impulseMover.enabled = true;
                }
                HeroRotator heroRotator = hero.GetComponent<HeroRotator>();
                if (heroRotator != null)
                {
                    heroRotator.enabled = true;
                }
                GameObject CubeSprite = hero.transform.Find("Contaner/CubeSprite")?.gameObject;
                if (CubeSprite != null)
                {
                    CubeSprite.SetActive(true);
                }
                if (rb != null)
                {
                    rb.gravityScale = 8f; 
                }
                break;
            case GameMode.Ship:
                disableEverything(hero);
                ShipBehaviour shipBehaviour = hero.GetComponent<ShipBehaviour>();
                if (shipBehaviour != null)
                {
                    shipBehaviour.enabled = true;
                }
                GameObject ShipSprite = hero.transform.Find("Contaner/ShipSprite")?.gameObject;
                if (ShipSprite != null)
                {
                    ShipSprite.SetActive(true);
                }
                if (rb != null)
                {
                    rb.gravityScale = 5f;
                }
                break;
            default:
                Debug.LogError("Unsupported game mode: " + gameMode);
                break;
        }
    }
    static private void disableEverything(GameObject hero)
    {
        ImpulseMover impulseMover = hero.GetComponent<ImpulseMover>();
        if (impulseMover != null)
        {
            impulseMover.enabled = false;
        }
        HeroRotator heroRotator = hero.GetComponent<HeroRotator>();
        if (heroRotator != null)
        {
            heroRotator.enabled = false;
        }
        ShipBehaviour shipBehaviour = hero.GetComponent<ShipBehaviour>();
        if (shipBehaviour != null)
        {
            shipBehaviour.enabled = false;
        }
        GameObject CubeSprite = hero.transform.Find("Contaner/CubeSprite")?.gameObject;
        if (CubeSprite != null)
        {
            CubeSprite.SetActive(false);
        }
        GameObject ShipSprite = hero.transform.Find("Contaner/ShipSprite")?.gameObject;
        if (ShipSprite != null)
        {
            ShipSprite.SetActive(false);
        }
    }
}
