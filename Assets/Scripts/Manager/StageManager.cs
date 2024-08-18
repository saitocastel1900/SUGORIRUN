using UnityEngine;

/// <summary>
/// ステージに関することを管理する
/// </summary>
public class StageManager : MonoBehaviour
{
    /// <summary>
    /// RectTransform
    /// </summary>
    [SerializeField] private RectTransform _canvasTransform;
    
    /// <summary>
    /// 敵のサイズ
    /// </summary>
    [SerializeField] private float _enemySize = 140f;
    
    /// <summary>
    /// 敵の横間隔
    /// </summary>
    [SerializeField] private float _enemyDistanceX = 150f;
    
    /// <summary>
    /// 敵の縦間隔
    /// </summary>
    [SerializeField] private float _enemyDistanceY = 140f;

    /// <summary>
    /// 敵を生成する数を取得する
    /// </summary>
    /// <returns>敵の生成する数</returns>
    public int GetEnemyCount()
    {
        var rect = _canvasTransform.rect;
        return Mathf.FloorToInt(rect.width / _enemySize);
    }
    
    /// <summary>
    /// 生成位置のX座標を取得する
    /// </summary>
    /// <param name="scale">倍率</param>
    /// <returns>X座標</returns>
    public float GetX(int scale)
    {
        return -_canvasTransform.rect.width / 2 + _enemySize + _enemyDistanceX * scale;
    }
    
    /// <summary>
    /// 生成位置のランダムY座標を取得する
    /// </summary>
    /// <returns>Y座標</returns>
    public float GetRandomY()
    {
        var minHeight = _enemyDistanceY;
        var maxHeight = _canvasTransform.rect.height - minHeight;
        return Random.Range(minHeight, maxHeight);
    }

    /// <summary>
    /// 再生成する時に閾値のY座標
    /// </summary>
    /// <returns>Y座標</returns>
    public float GetLimitY()
    {
        var rect = _canvasTransform.rect;
        return -rect.height / 2 - _enemySize;
    }
    
    /// <summary>
    /// 再生成するときのY座標
    /// </summary>
    /// <returns>Y座標</returns>
    public float GetRecycleDistanceY()
    {
        var rect = _canvasTransform.rect;
        return rect.height/2+_enemySize;
    }
}
