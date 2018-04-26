Imports System.Collections.Generic

Public Class Product
    Public Property ProductID() As Integer
    Public Property ProductName() As String
    Public Property UnitPrice() As Decimal?
    Public Property UnitsOnOrder() As Short?

    Public Shared Function GetData() As List(Of Product)
        Dim products As New List(Of Product)()

        products.Add(New Product() With { _
            .ProductID = 1, _
            .ProductName = "Chai", _
            .UnitPrice = 19, _
            .UnitsOnOrder = 0 _
        })
        products.Add(New Product() With { _
            .ProductID = 2, _
            .ProductName = "Chang", _
            .UnitPrice = 19, _
            .UnitsOnOrder = 40 _
        })
        products.Add(New Product() With { _
            .ProductID = 3, _
            .ProductName = "Aniseed Syrup", _
            .UnitPrice = 10, _
            .UnitsOnOrder = 70 _
        })

        products.Add(New Product() With { _
            .ProductID = 4, _
            .ProductName = "Chef Anton's Cajun Seasoning", _
            .UnitPrice = 22, _
            .UnitsOnOrder = 0 _
        })
        products.Add(New Product() With { _
            .ProductID = 5, _
            .ProductName = "Chef Anton's Gumbo Mix", _
            .UnitPrice = 21.35D, _
            .UnitsOnOrder = 0 _
        })
        products.Add(New Product() With { _
            .ProductID = 6, _
            .ProductName = "Grandma's Boysenberry Spread", _
            .UnitPrice = 25, _
            .UnitsOnOrder = 0 _
        })

        products.Add(New Product() With { _
            .ProductID = 7, _
            .ProductName = "Uncle Bob's Organic Dried Pears", _
            .UnitPrice = 30, _
            .UnitsOnOrder = 0 _
        })
        products.Add(New Product() With { _
            .ProductID = 8, _
            .ProductName = "Northwoods Cranberry Sauce", _
            .UnitPrice = 40, _
            .UnitsOnOrder = 0 _
        })
        products.Add(New Product() With { _
            .ProductID = 9, _
            .ProductName = "Mishi Kobe Niku", _
            .UnitPrice = 97, _
            .UnitsOnOrder = 0 _
        })

        products.Add(New Product() With { _
            .ProductID = 10, _
            .ProductName = "Ikura", _
            .UnitPrice = 31, _
            .UnitsOnOrder = 0 _
        })
        products.Add(New Product() With { _
            .ProductID = 11, _
            .ProductName = "Queso Cabrales", _
            .UnitPrice = 21, _
            .UnitsOnOrder = 30 _
        })
        products.Add(New Product() With { _
            .ProductID = 12, _
            .ProductName = "Queso Manchego La Pastora", _
            .UnitPrice = 38, _
            .UnitsOnOrder = 0 _
        })

        Return products
    End Function
End Class