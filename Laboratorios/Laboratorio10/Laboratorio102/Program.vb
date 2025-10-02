Module area
    Sub Main()
        Dim radio As Single
        Dim area As Single
        Dim circuferencia As Single
        Const pi = 3.1415926

        Console.WriteLine("Ingrese el radio: ")
        radio = Console.ReadLine()

        area = pi * radio ^ 2
        circuferencia = 2 * pi * radio
        Console.WriteLine("El area es: {0}", area)
        Console.WriteLine("La circuferencia es: {0}", circuferencia)
        Console.ReadKey()
    End Sub
End Module