using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm_Tile : MonoBehaviour
{
    public bool empty = true;

    private float _timePassed;
    private int _currentStage;
    private bool _grown;
    private Plant _plant;

    void Update()
    {
        
    }

    public void Planting() // Plants the plant
    {
        StartCoroutine(GrowPlant());
        _grown = false;
        _currentStage = 0;
        _timePassed = 0f;
    }

    public IEnumerator GrowPlant() // Grows the plant and progresses it through its growth stages
    {
        while (!empty)
        {
            _timePassed += Time.deltaTime;
            if (_timePassed >= _plant.growthTime && !_grown) // Progresses to next stage of growth
            {
                _timePassed = 0f;
                _currentStage += 1;
                _plant.sr.sprite = _plant.stages[_currentStage];
            }

            if (_currentStage == _plant.stages.Length - 1 && !_grown) // checks if its grown
            {
                _grown = true;
                _timePassed = 0f;
            }

            if (_grown && _timePassed > _plant.wiltTime) // Plant will die if not harvested in time
            {
                Destroy(_plant.gameObject);
                empty = true;
                break;
            }

            yield return null;
        }
    }

    public void HarvestPlant()
    {
        Destroy(_plant.gameObject);
        empty = true;
        StopCoroutine(GrowPlant());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Seed Bag" && empty)
        {
            empty = false;
            GameObject temp = Instantiate(collision.gameObject.GetComponent<SeedBag>().plant, transform);
            _plant = temp.GetComponent<Plant>();
            Planting();

        }
    }

    private void OnMouseDown()
    {
        if (_grown)
        {
            HarvestPlant();
        }
    }
}
