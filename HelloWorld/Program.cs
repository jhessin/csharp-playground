using Gtk;
using System;

enum Mode { GTK, Nullables, Overloading }

class Box {
  private static readonly double EPSILON = 0.001;
  private double length;  // Length of the box
  private double breadth; // Breadth of the box
  private double height;  // Height of the box

  public double Volume => length * breadth * height;
  public double Length { set => length = value; }
  public double Breadth { set => breadth = value; }
  public double Height { set => height = value; }

  public static Box operator + (Box b, Box c) {
    Box a = new Box {
      length = b.length + c.length,
      breadth = b.breadth + c.breadth,
      height = b.height + c.height
    };
    return a;
  }

  public static bool operator == (Box lhs, Box rhs) =>
    Math.Abs (lhs.length - rhs.length) < EPSILON &&
    Math.Abs (lhs.height - rhs.height) < EPSILON &&
    Math.Abs (lhs.breadth - rhs.breadth) < EPSILON;
  public static bool operator != (Box lhs, Box rhs) =>
    Math.Abs (lhs.length - rhs.length) > EPSILON ||
    Math.Abs (lhs.breadth - rhs.breadth) > EPSILON ||
    Math.Abs (lhs.height - rhs.height) > EPSILON;

  public static bool operator < (Box lhs, Box rhs) =>
    lhs.length < rhs.length &&
    lhs.breadth < rhs.breadth &&
    lhs.height < rhs.height;
  public static bool operator > (Box lhs, Box rhs) =>
    lhs.length > rhs.length &&
    lhs.breadth > rhs.breadth &&
    lhs.height > rhs.height;

  public static bool operator <= (Box lhs, Box rhs) =>
    lhs < rhs || lhs == rhs;

  public static bool operator >= (Box lhs, Box rhs) =>
    lhs > rhs || lhs == rhs;

  public override string ToString () =>
    String.Format ("({0}, {1}, {2}) = {3}", length, breadth, height, Volume);
}

class Hello {
  static void Main () {
    Mode mode = Mode.Overloading;


    switch (mode) {
    case Mode.GTK:
      /* -- GTK (More experimentation) */
      Application.Init ();

      Window window = new Window ("Hello Mono World");

      Label label = new Label ("Hello World!");
      window.Add (label);
      window.Show ();

      Application.Run ();
      break;
    case Mode.Nullables:
      /* -- NULLABLES!!!! */
      double? num1 = null;
      double? num2 = 3.14157;
      double num3;

      num3 = num1 ?? num2 ?? 5.94;
      Console.WriteLine (num3);
      break;
    case Mode.Overloading:
      // box1 spec
      Box box1 = new Box {
        Length = 6.0,
        Breadth = 7.0,
        Height = 5.0
      };
      // box2 spec
      Box box2 = new Box {
        Length = 12,
        Breadth = 13.0,
        Height = 10
      };
      // box3 spec
      Box box3 = new Box ();

      // Volume of box 1
      Console.WriteLine (box1);
      // Volume of box 2
      Console.WriteLine (box2);

      // Add boxes
      box3 = box1 + box2;

      // Volume of box3
      Console.WriteLine (box3);
      break;
    }
  }
}