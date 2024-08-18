using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// 敵を供給する
/// </summary>
public class EnemyProvider : MonoBehaviour
{
    /// <summary>
    /// 敵のリスト
    /// </summary>
    public Dictionary<int,EnemyCore> Enemies => _enemies;
    private Dictionary<int,EnemyCore> _enemies = new Dictionary<int,EnemyCore>();
    
    /// <summary>
    /// 敵のPrefab
    /// </summary>
    [SerializeField] private Image _enemyPrefab;
    
    /// <summary>
    /// 生成元
    /// </summary>
    [SerializeField] private RectTransform _parentTransform;
    
    /// <summary>
    /// 敵を生成する
    /// </summary>
    /// <param name="x">生成座標X</param>
    /// <param name="y">生成座標Y</param>
    /// <param name="limitY">再生成する時に閾値のY座標</param>
    /// <param name="recycleDistanceY">再生成するときのY座標</param>
    /// <param name="id">生成個体番数</param>
    public void CreateEnemy(float x, float y, float limitY, float recycleDistanceY,int id)
    {
        //既に生成していたら使いまわす
        if (_enemies != null && _enemies.Count > 0 && _enemies.ContainsKey(id))
        {
            _enemies[id].transform.position = new Vector3(x, y, 0);
            _enemies[id].InitializeEnemy(limitY,x, recycleDistanceY);
        }
        //初プレイなら、新規生成する
        else
        {
            var enemyObject = Instantiate(_enemyPrefab);
            enemyObject.transform.position = new Vector3(x, y, 0);
            var core = enemyObject.GetComponent<EnemyCore>();
            core.InitializeEnemy(limitY, x, recycleDistanceY);
            _enemies.Add(id,core);
            enemyObject.transform.SetParent(_parentTransform, false);
        }
    }
}