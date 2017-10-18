using UnityEngine;

[System.Serializable]
public struct Point2 {

    public static Point2 down { get { return new Point2(0, -1); } }
    public static Point2 left { get { return new Point2(-1, 0); } }
    public static Point2 one { get { return new Point2(1, 1); } }
    public static Point2 right { get { return new Point2(1, 0); } }
    public static Point2 up { get { return new Point2(0, 1); } }
    public static Point2 zero { get { return new Point2(0, 0); } }
    
    public Vector2 toVector2 { get { return new Vector2(x, y); } }
    public Vector3 toVector3 { get { return new Vector3(x, y, 0.0f); } }

    public override string ToString() {
        return string.Format("({0}, {1})", x, y);
    }

    public override bool Equals(object obj) {
        return base.Equals(obj);
    }

    public override int GetHashCode() {
        return base.GetHashCode();
    }

    public int length { get { return Mathf.Abs(x) + Mathf.Abs(y); } }

    public int x;
    public int y;
    
    public Point2(Vector2 position) : this(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)) { }
    public Point2(Vector3 position) : this(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)) { }
    public Point2(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public static bool operator ==(Point2 a, Point2 b) {
        return a.x == b.x && a.y == b.y;
    }

    public static bool operator !=(Point2 a, Point2 b) {
        return a.x != b.x || a.y != b.y;
    }

    public static Point2 operator +(Point2 a, Point2 b) {
        return new Point2(a.x + b.x, a.y + b.y);
    }

    public static Point2 operator -(Point2 a, Point2 b) {
        return new Point2(a.x - b.x, a.y - b.y);
    }

    public static Point2 operator *(Point2 a, int value) {
        return new Point2(a.x * value, a.y * value);
    }

    public static int Distance(Point2 a, Point2 b) {
        return Mathf.Abs(b.x - a.x) + Mathf.Abs(b.y - a.y);
    }
}
