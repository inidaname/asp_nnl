Imports Microsoft.VisualBasic

Public Class Number2Words
#Region "Number to word"

    Dim CNum As String
    Dim US(1003) As String
    Dim SNu(20) As String
    Dim SNt(10) As String
    Dim iSdEC As Boolean
    Dim guM() As String

    Private Function feelFree(ByVal M As String) As String
        On Error GoTo errh
        guM = Split(M, ".")
        feelFree = guM(0)
        iSdEC = False

        If guM.Length > 1 Then
            'Num = guM(0)
            iSdEC = True
        End If
        Exit Function
errh:   iSdEC = False
    End Function

    Dim _Currency, _dotSide As String

    Property dotSide() As String
        Get
            Return _dotSide
        End Get
        Set(ByVal value As String)
            _dotSide = value
        End Set
    End Property

    Property Currency() As String
        Get
            Return _Currency
        End Get
        Set(ByVal value As String)
            _Currency = value
        End Set
    End Property

    Function ConvertNow(ByVal Num As String) As String
        Try

            Initialize()

            If _Currency = "" Then _Currency = "Dollars"
            If _dotSide = "" Then _dotSide = "Cents"

            _Currency = " " & _Currency.Trim & " "
            _dotSide = " " & _dotSide.Trim() & " "


            Dim ConvertedValues As String = ""
            Dim result_1 As Double

            If Double.TryParse(Num, result_1) = False Then Return ""

            Num = Trim(Num)
            Num = Replace(Num, ",", "")
            CNum = Num

            Num = feelFree(Num)


            If Val(Num) < 20 Then
                ConvertedValues = Less20(Num)
                ConvertNow = ConvertedValues
            End If

            If Val(Num) > 19 And Val(Num) < 100 Then
                ConvertedValues = G20Less100(Num)
                ConvertNow = ConvertedValues
            End If

            If Val(Num) >= 100 And Val(Num) < 1000 Then
                ConvertedValues = ABOVE100(Num)
                ConvertNow = ConvertedValues
            End If

            If Val(Num) >= 1000 And Val(Num) < 1000000 Then
                ConvertedValues = Above1000(Num)
                ConvertNow = ConvertedValues
            End If

            If Val(Num) >= 1000000 And Val(Num) < 1000000000 Then
                ConvertedValues = GoneMil(Num)
                ConvertNow = ConvertedValues
            End If

            If Val(Num) >= 1000000000 And Val(Num) < 1000000000000.0# Then
                ConvertedValues = GoneBil(Num)
                ConvertNow = ConvertedValues
            End If

            If Val(Num) >= 1000000000000.0# And Val(Num) < 1.0E+15 Then
                ConvertedValues = GoneTri(Num)
                ConvertNow = ConvertedValues
            End If

            If Val(Num) >= 1.0E+15 And Val(Num) < 1.0E+18 Then
                ConvertedValues = GoneQuad(Num)
                ConvertNow = ConvertedValues
            End If

            If Val(Num) >= 1.0E+18 And Val(Num) < 1.0E+21 Then
                ConvertedValues = GoneQuin(Num)
                ConvertNow = ConvertedValues
            End If

            If Val(Num) >= 1.0E+21 And Val(Num) < 1.0E+24 Then
                ConvertedValues = GoneSex(Num)
                ConvertNow = ConvertedValues
            End If

            If Val(Num) >= 1.0E+24 And Val(Num) < 1.0E+27 Then
                ConvertedValues = GoneSept(Num)
                ConvertNow = ConvertedValues
            End If

            If Val(Num) >= 1.0E+27 And Val(Num) < 1.0E+30 Then
                ConvertedValues = GoneOct(Num)
                ConvertNow = ConvertedValues
            End If

            If Val(Num) >= 1.0E+30 And Val(Num) < 1.0E+33 Then
                ConvertedValues = GoneNona(Num)
                ConvertNow = ConvertedValues
            End If

            If Val(Num) >= 1.0E+33 And Val(Num) < 1.0E+36 Then
                ConvertedValues = GoneDeca(Num)
                ConvertNow = ConvertedValues
            End If


            If iSdEC = True Then
                If Trim(G20Less100(guM(1))) = "" Then
                    ConvertNow = Replace(ConvertedValues, "  ", " ") & _Currency & "Only"
                Else
                    If Val(Num) < 1 Then
                        ConvertNow = Replace(ConvertedValues, "  ", " ") & G20Less100(Microsoft.VisualBasic.Left(guM(1), 2)) & _dotSide
                    Else
                        ConvertNow = Replace(ConvertedValues, "  ", " ") & _Currency & G20Less100(Microsoft.VisualBasic.Left(guM(1), 2)) & _dotSide
                    End If
                End If

            Else
                ConvertNow = Replace(ConvertedValues, "  ", " ") & _Currency & "Only"
            End If

            If Trim(ConvertedValues) = _Currency & "Only" Then ConvertNow = ""

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function GoneDeca(ByVal M As String) As String
        Dim Result As String = ""


        If Len(M) = 34 Then
            If Trim(Less20(Left(M, 1))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 33) = "000000000000000000000000000000000", "", GoneNona(Microsoft.VisualBasic.Right(M, 33)))
            Else
                Result = Less20(Left(M, 1)) & " Decallion " & IIf(Microsoft.VisualBasic.Right(M, 33) = "000000000000000000000000000000000", "", GoneNona(Microsoft.VisualBasic.Right(M, 33)))
            End If

        ElseIf Len(M) = 35 Then
            If Trim(G20Less100(Left(M, 2))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 33) = "000000000000000000000000000000000", "", GoneNona(Microsoft.VisualBasic.Right(M, 33)))
            Else
                Result = G20Less100(Left(M, 2)) & " Decallion " & IIf(Microsoft.VisualBasic.Right(M, 33) = "000000000000000000000000000000000", "", GoneNona(Right(M, 33)))
            End If

        ElseIf Len(M) = 36 Then
            If Trim(ABOVE100(Left(M, 3))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 33) = "000000000000000000000000000000000", "", GoneNona(Microsoft.VisualBasic.Right(M, 33)))
            Else
                Result = ABOVE100(Left(M, 3)) & " Decallion " & IIf(Microsoft.VisualBasic.Right(M, 33) = "000000000000000000000000000000000", "", GoneNona(Microsoft.VisualBasic.Right(M, 33)))
            End If

        End If

        Return Result


    End Function

    Private Function GoneNona(ByVal M As String) As String
        Dim Result As String = ""

        If Len(M) = 31 Then
            If Trim(Less20(Left(M, 1))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 30) = "000000000000000000000000000000", "", GoneOct(Microsoft.VisualBasic.Right(M, 30)))
            Else
                Result = Less20(Left(M, 1)) & " Nonallion " & IIf(Microsoft.VisualBasic.Right(M, 30) = "000000000000000000000000000000", "", GoneOct(Microsoft.VisualBasic.Right(M, 30)))
            End If

        ElseIf Len(M) = 32 Then
            If Trim(G20Less100(Left(M, 2))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 30) = "000000000000000000000000000000", "", GoneOct(Microsoft.VisualBasic.Right(M, 30)))
            Else
                Result = G20Less100(Left(M, 2)) & " Nonallion " & IIf(Microsoft.VisualBasic.Right(M, 30) = "000000000000000000000000000000", "", GoneOct(Microsoft.VisualBasic.Right(M, 30)))
            End If

        ElseIf Len(M) = 33 Then
            If Trim(ABOVE100(Left(M, 3))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 30) = "000000000000000000000000000000", "", GoneOct(Microsoft.VisualBasic.Right(M, 30)))
            Else
                Result = ABOVE100(Left(M, 3)) & " Nonallion " & IIf(Microsoft.VisualBasic.Right(M, 30) = "000000000000000000000000000000", "", GoneOct(Microsoft.VisualBasic.Right(M, 30)))
            End If

        End If

        Return Result
    End Function

    Private Function GoneOct(ByVal M As String) As String
        Dim Result As String = ""

        If Len(M) = 28 Then
            If Trim(Less20(Left(M, 1))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 27) = "000000000000000000000000000", "", GoneSept(Microsoft.VisualBasic.Right(M, 27)))
            Else
                Result = Less20(Left(M, 1)) & " Octillion " & IIf(Microsoft.VisualBasic.Right(M, 27) = "000000000000000000000000000", "", GoneSept(Microsoft.VisualBasic.Right(M, 27)))
            End If

        ElseIf Len(M) = 29 Then
            If Trim(G20Less100(Left(M, 2))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 27) = "000000000000000000000000000", "", GoneSept(Microsoft.VisualBasic.Right(M, 27)))
            Else
                Result = G20Less100(Left(M, 2)) & " Octillion " & IIf(Microsoft.VisualBasic.Right(M, 27) = "000000000000000000000000000", "", GoneSept(Microsoft.VisualBasic.Right(M, 27)))
            End If

        ElseIf Len(M) = 30 Then
            If Trim(ABOVE100(Left(M, 3))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 27) = "000000000000000000000000000", "", GoneSept(Microsoft.VisualBasic.Right(M, 27)))
            Else
                Result = ABOVE100(Left(M, 3)) & " Octillion " & IIf(Microsoft.VisualBasic.Right(M, 27) = "000000000000000000000000000", "", GoneSept(Microsoft.VisualBasic.Right(M, 27)))
            End If

        End If

        Return Result
    End Function

    Private Function GoneSept(ByVal M As String) As String
        Dim Result As String = ""

        If Len(M) = 25 Then
            If Trim(Less20(Left(M, 1))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 24) = "000000000000000000000000", "", GoneSex(Microsoft.VisualBasic.Right(M, 24)))
            Else
                Result = Less20(Left(M, 1)) & " Septillion " & IIf(Microsoft.VisualBasic.Right(M, 24) = "000000000000000000000000", "", GoneSex(Microsoft.VisualBasic.Right(M, 24)))
            End If

        ElseIf Len(M) = 26 Then
            If Trim(G20Less100(Left(M, 2))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 24) = "000000000000000000000000", "", GoneSex(Microsoft.VisualBasic.Right(M, 24)))
            Else
                Result = G20Less100(Left(M, 2)) & " Septillion " & IIf(Microsoft.VisualBasic.Right(M, 24) = "000000000000000000000000", "", GoneSex(Microsoft.VisualBasic.Right(M, 24)))
            End If

        ElseIf Len(M) = 27 Then
            If Trim(ABOVE100(Left(M, 3))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 24) = "000000000000000000000000", "", GoneSex(Microsoft.VisualBasic.Right(M, 24)))
            Else
                Result = ABOVE100(Left(M, 3)) & " Septillion " & IIf(Microsoft.VisualBasic.Right(M, 24) = "000000000000000000000000", "", GoneSex(Microsoft.VisualBasic.Right(M, 24)))
            End If

        End If
        Return Result
    End Function

    Private Function GoneSex(ByVal M As String) As String
        Dim Result As String = ""

        If Len(M) = 22 Then
            If Trim(Less20(Left(M, 1))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 21) = "000000000000000000000", "", GoneQuin(Microsoft.VisualBasic.Right(M, 21)))
            Else
                Result = Less20(Left(M, 1)) & " Sextillion " & IIf(Microsoft.VisualBasic.Right(M, 21) = "000000000000000000000", "", GoneQuin(Microsoft.VisualBasic.Right(M, 21)))
            End If

        ElseIf Len(M) = 23 Then
            If Trim(G20Less100(Left(M, 2))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 21) = "000000000000000000000", "", GoneQuin(Microsoft.VisualBasic.Right(M, 21)))
            Else
                Result = G20Less100(Left(M, 2)) & " Sextillion " & IIf(Microsoft.VisualBasic.Right(M, 21) = "000000000000000000000", "", GoneQuin(Microsoft.VisualBasic.Right(M, 21)))
            End If

        ElseIf Len(M) = 24 Then
            If Trim(ABOVE100(Left(M, 3))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 21) = "000000000000000000000", "", GoneQuin(Microsoft.VisualBasic.Right(M, 21)))
            Else
                Result = ABOVE100(Left(M, 3)) & " Sextillion " & IIf(Microsoft.VisualBasic.Right(M, 21) = "000000000000000000000", "", GoneQuin(Microsoft.VisualBasic.Right(M, 21)))
            End If

        End If

        Return Result
    End Function

    Private Function GoneQuin(ByVal M As String) As String
        Dim Result As String = ""

        If Len(M) = 19 Then
            If Trim(Less20(Left(M, 1))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 18) = "000000000000000000", "", GoneQuad(Microsoft.VisualBasic.Right(M, 18)))
            Else
                Result = Less20(Left(M, 1)) & " Quintillion " & IIf(Microsoft.VisualBasic.Right(M, 18) = "000000000000000000", "", GoneQuad(Microsoft.VisualBasic.Right(M, 18)))
            End If

        ElseIf Len(M) = 20 Then
            If Trim(G20Less100(Left(M, 2))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 18) = "000000000000000", "", GoneQuad(Microsoft.VisualBasic.Right(M, 18)))
            Else
                Result = G20Less100(Left(M, 2)) & " Quintillion " & IIf(Microsoft.VisualBasic.Right(M, 18) = "000000000000000", "", GoneQuad(Microsoft.VisualBasic.Right(M, 18)))
            End If

        ElseIf Len(M) = 21 Then
            If Trim(ABOVE100(Left(M, 3))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 18) = "000000000000000", "", GoneQuad(Microsoft.VisualBasic.Right(M, 18)))
            Else
                Result = ABOVE100(Left(M, 3)) & " Quintillion " & IIf(Microsoft.VisualBasic.Right(M, 18) = "000000000000000", "", GoneQuad(Microsoft.VisualBasic.Right(M, 18)))
            End If

        End If

        Return Result

    End Function

    Private Function GoneQuad(ByVal M As String) As String
        Dim Result As String = ""

        If Len(M) = 16 Then
            If Trim(Less20(Left(M, 1))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 15) = "000000000000000", "", GoneTri(Microsoft.VisualBasic.Right(M, 15)))
            Else
                Result = Less20(Left(M, 1)) & " Quadrillion " & IIf(Microsoft.VisualBasic.Right(M, 15) = "000000000000000", "", GoneTri(Microsoft.VisualBasic.Right(M, 15)))
            End If

        ElseIf Len(M) = 17 Then
            If Trim(G20Less100(Left(M, 2))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 15) = "000000000000000", "", GoneTri(Microsoft.VisualBasic.Right(M, 15)))
            Else
                Result = G20Less100(Left(M, 2)) & " Quadrillion " & IIf(Microsoft.VisualBasic.Right(M, 15) = "000000000000000", "", GoneTri(Microsoft.VisualBasic.Right(M, 15)))
            End If

        ElseIf Len(M) = 18 Then
            If Trim(ABOVE100(Left(M, 3))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 15) = "000000000000000", "", GoneTri(Microsoft.VisualBasic.Right(M, 15)))
            Else
                Result = ABOVE100(Left(M, 3)) & " Quadrillion " & IIf(Microsoft.VisualBasic.Right(M, 15) = "000000000000000", "", GoneTri(Microsoft.VisualBasic.Right(M, 15)))
            End If

        End If

        Return Result


    End Function

    Private Function GoneTri(ByVal M As String) As String
        Dim Result As String = ""

        If Len(M) = 13 Then
            If Trim(Less20(Left(M, 1))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 12) = "000000000000", "", GoneBil(Microsoft.VisualBasic.Right(M, 12)))
            Else
                Result = Less20(Left(M, 1)) & " Trillion " & IIf(Microsoft.VisualBasic.Right(M, 12) = "000000000000", "", GoneBil(Microsoft.VisualBasic.Right(M, 12)))
            End If

        ElseIf Len(M) = 14 Then
            If Trim(G20Less100(Left(M, 2))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 12) = "000000000000", "", GoneBil(Microsoft.VisualBasic.Right(M, 12)))
            Else
                Result = G20Less100(Left(M, 2)) & " Trillion " & IIf(Microsoft.VisualBasic.Right(M, 12) = "000000000000", "", GoneBil(Microsoft.VisualBasic.Right(M, 12)))
            End If

        ElseIf Len(M) = 15 Then
            If Trim(ABOVE100(Left(M, 3))) = "" Then
                Result = " " & IIf(Microsoft.VisualBasic.Right(M, 12) = "000000000000", "", GoneBil(Microsoft.VisualBasic.Right(M, 12)))
            Else
                Result = ABOVE100(Left(M, 3)) & " Trillion " & IIf(Microsoft.VisualBasic.Right(M, 12) = "000000000000", "", GoneBil(Microsoft.VisualBasic.Right(M, 12)))
            End If

        End If
        Return Result
    End Function

    Private Function GoneBil(ByVal M As String) As String
        Dim Result As String = ""

        If Len(M) = 10 Then
            If Trim(Less20(Left(M, 1))) = "" Then
                Result = IIf(Microsoft.VisualBasic.Right(M, 9) = "000000000", "", GoneMil(Microsoft.VisualBasic.Right(M, 9)))
            Else
                Result = Less20(Left(M, 1)) & " Billion " & IIf(Microsoft.VisualBasic.Right(M, 9) = "000000000", "", GoneMil(Microsoft.VisualBasic.Right(M, 9)))
            End If

        ElseIf Len(M) = 11 Then
            If Trim(G20Less100(Left(M, 2))) = "" Then
                Result = IIf(Microsoft.VisualBasic.Right(M, 9) = "000000000", "", GoneMil(Microsoft.VisualBasic.Right(M, 9)))
            Else
                Result = G20Less100(Left(M, 2)) & " Billion " & IIf(Microsoft.VisualBasic.Right(M, 9) = "000000000", "", GoneMil(Microsoft.VisualBasic.Right(M, 9)))
            End If

        ElseIf Len(M) = 12 Then
            If Trim(ABOVE100(Left(M, 3))) = "" Then
                Result = IIf(Microsoft.VisualBasic.Right(M, 9) = "000000000", "", GoneMil(Microsoft.VisualBasic.Right(M, 9)))
            Else
                Result = ABOVE100(Left(M, 3)) & " Billion " & IIf(Microsoft.VisualBasic.Right(M, 9) = "000000000", "", GoneMil(Microsoft.VisualBasic.Right(M, 9)))
            End If

        End If

        Return Result
    End Function

    Private Function GoneMil(ByVal M As String) As String
        Dim Result As String = ""

        If Len(M) = 7 Then
            If Trim(Less20(Left(M, 1))) = "" Then
                Result = IIf(Microsoft.VisualBasic.Right(M, 6) = "000000", "", Above1000(Microsoft.VisualBasic.Right(M, 6)))
            Else
                Result = Less20(Left(M, 1)) & " Million " & IIf(Microsoft.VisualBasic.Right(M, 6) = "000000", "", Above1000(Microsoft.VisualBasic.Right(M, 6)))
            End If

        ElseIf Len(M) = 8 Then
            If Trim(G20Less100(Left(M, 2))) = "" Then
                Result = IIf(Microsoft.VisualBasic.Right(M, 6) = "000000", "", Above1000(Microsoft.VisualBasic.Right(M, 6)))
            Else
                Result = G20Less100(Left(M, 2)) & " Million " & IIf(Microsoft.VisualBasic.Right(M, 6) = "000000", "", Above1000(Microsoft.VisualBasic.Right(M, 6)))
            End If

        ElseIf Len(M) = 9 Then
            If Trim(ABOVE100(Left(M, 3))) = "" Then
                Result = IIf(Microsoft.VisualBasic.Right(M, 6) = "000000", "", Above1000(Microsoft.VisualBasic.Right(M, 6)))
            Else
                Result = ABOVE100(Left(M, 3)) & " Million " & IIf(Microsoft.VisualBasic.Right(M, 6) = "000000", "", Above1000(Microsoft.VisualBasic.Right(M, 6)))
            End If

        End If

        Return Result
    End Function

    Private Function Less20(ByVal Less20NMo As String) As String
        Return SNu(Val(Less20NMo))
    End Function

    Private Function G20Less100(ByVal GE20 As String) As String

        If Val(GE20) < 20 Then
            Return SNu(Val(GE20))
        Else
            Return SNt(Val(Left(GE20, 1))) & " " & Less20(Microsoft.VisualBasic.Right(GE20, 1))
        End If
    End Function

    Private Function ABOVE100(ByVal M As String) As String

        If Val(M) = 0 Then
            ABOVE100 = " " & G20Less100(Microsoft.VisualBasic.Right(M, 2))
        ElseIf Val(M) < 100 Then
            If Trim(G20Less100(Microsoft.VisualBasic.Right(M, 2))) <> "" Then
                ABOVE100 = " And " & G20Less100(Microsoft.VisualBasic.Right(M, 2))
            Else
                ABOVE100 = " "
            End If

        ElseIf Microsoft.VisualBasic.Right(M, 2) = "00" Then
            If Trim(Less20(Left(M, 1))) = "" Then
                ABOVE100 = " " & G20Less100(Microsoft.VisualBasic.Right(M, 2))
            Else
                ABOVE100 = Less20(Left(M, 1)) & " Hundred " & G20Less100(Microsoft.VisualBasic.Right(M, 2))

            End If

        ElseIf Microsoft.VisualBasic.Right(M, 3) = "" Then
            ABOVE100 = Less20(Left(M, 1)) & " " & G20Less100(Microsoft.VisualBasic.Right(M, 2))
        Else
            If Trim(Less20(Left(M, 1))) = "" Then
                ABOVE100 = " " & G20Less100(Microsoft.VisualBasic.Right(M, 2))

            Else
                If Trim(G20Less100(Microsoft.VisualBasic.Right(M, 2))) <> "" Then
                    ABOVE100 = Less20(Left(M, 1)) & " Hundred And " & G20Less100(Microsoft.VisualBasic.Right(M, 2))
                Else
                    ABOVE100 = Less20(Left(M, 1)) & " Hundred "
                End If


            End If

        End If

    End Function

    Private Function Above1000(ByVal M As String) As String
        Dim Result As String = ""

        If Len(M) = 4 Then
            If Trim(Less20(Left(M, 1))) = "" Then
                Result = " " & ABOVE100(Microsoft.VisualBasic.Right(M, 3))
            Else

                Result = Less20(Left(M, 1)) & " Thousand " & ABOVE100(Microsoft.VisualBasic.Right(M, 3))

            End If
        End If


        If Len(M) = 5 Then
            If Trim(G20Less100(Left(M, 2))) = "" Then
                Result = " " & ABOVE100(Microsoft.VisualBasic.Right(M, 3))
            Else
                If Val(CNum) > 10000 Then
                    If Microsoft.VisualBasic.Right(CNum, 3) = "000" Then
                        Result = G20Less100(Left(M, 2)) & "  Thousand " & ABOVE100(Microsoft.VisualBasic.Right(M, 3))
                    Else
                        If Trim(ABOVE100(Microsoft.VisualBasic.Right(M, 3))) <> "" Then
                            Result = G20Less100(Left(M, 2)) & "  Thousand And " & ABOVE100(Microsoft.VisualBasic.Right(M, 3))
                        Else
                            Result = G20Less100(Left(M, 2)) & "  Thousand "
                        End If
                    End If

                Else
                    Result = G20Less100(Left(M, 2)) & " Thousand " & ABOVE100(Microsoft.VisualBasic.Right(M, 3))
                End If

            End If

        End If

        If Len(M) = 6 Then
            If Val(Microsoft.VisualBasic.Right(M, 6)) < 1000 Then
                Result = Replace(ABOVE100(Left(M, 3)), " And ", " ") & " " & ABOVE100(Microsoft.VisualBasic.Right(M, 3))
            Else

                ' Result  = Replace(ABOVE100(Left(m, 3)), " And ", " ") & " Thousand " & ABOVE100(Microsoft.VisualBasic.right(m, 3))

                Result = ABOVE100(Left(M, 3)) & " Thousand " & ABOVE100(Microsoft.VisualBasic.Right(M, 3))

            End If

        End If

        Return Result
    End Function

    Private Sub Initialize()

        SNu(0) = ""
        SNu(1) = "One"
        SNu(2) = "Two"
        SNu(3) = "Three"
        SNu(4) = "Four"
        SNu(5) = "Five"
        SNu(6) = "Six"
        SNu(7) = "Seven"
        SNu(8) = "Eight"
        SNu(9) = "Nine"
        SNu(10) = "Ten"
        SNu(11) = "Eleven"
        SNu(12) = "Twelve"
        SNu(13) = "Thirteen"
        SNu(14) = "Fourteen"
        SNu(15) = "Fifteen"
        SNu(16) = "Sixteen"
        SNu(17) = "Seventeen"
        SNu(18) = "Eighteen"
        SNu(19) = "Nineteen"
        SNt(2) = "Twenty"
        SNt(3) = "Thirty"
        SNt(4) = "Forty"
        SNt(5) = "Fifty"
        SNt(6) = "Sixty"
        SNt(7) = "Seventy"
        SNt(8) = "Eighty"
        SNt(9) = "Ninety"
        US(1) = ""
        US(2) = "Thousand"
        US(3) = "Million"
        US(4) = "Billion"
        US(5) = "Trillion"
        US(6) = "Quadrillion"
        US(7) = "Quintillion"
        US(8) = "Sextillion"
        US(9) = "Septillion"
        US(10) = "Octillion"


    End Sub

#End Region
End Class
