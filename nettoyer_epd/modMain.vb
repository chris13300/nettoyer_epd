Module modMain

    Sub Main()
        Dim chaine As String, lecture As System.IO.StreamReader, mem As String, x As Integer, y As Integer, nb As Integer, tmp() As String
        Dim nameEPD As String, fileTMP As String, start As Integer

        nameEPD = My.Computer.FileSystem.GetName(Command())
        If nameEPD = "" Then
            Console.WriteLine("command : nettoyer_epd.exe your_epd_file.epd")
            Console.ReadLine()
            End
        End If

        fileTMP = Replace(Command(), ".epd", ".tmp")
        If My.Computer.FileSystem.FileExists(fileTMP) Then
            My.Computer.FileSystem.DeleteFile(fileTMP)
        End If

        y = Console.CursorTop
        x = Console.CursorLeft

        mem = ""
        nb = 0
        lecture = My.Computer.FileSystem.OpenTextFileReader(Command())
        start = Environment.TickCount
        While Not lecture.EndOfStream
            chaine = lecture.ReadLine
            If chaine = "" And mem <> "" Then
                tmp = Split(mem, " ")
                chaine = tmp(0) & " " & tmp(1) & " " & tmp(2) & " " & tmp(3) & vbCrLf
                My.Computer.FileSystem.WriteAllText(fileTMP, chaine, True)
                mem = ""
                nb = nb + 1
                If nb Mod 500 = 0 Then
                    Console.SetCursorPosition(x, y)
                    Console.Write("cleaning : " & nb & " positions (" & Format(nb / (Environment.TickCount - start) * 1000, "0") & " pos/sec)   ")
                End If
            Else
                mem = chaine
            End If
        End While
        lecture.Close()
        lecture = Nothing
        My.Computer.FileSystem.DeleteFile(Command())
        My.Computer.FileSystem.RenameFile(fileTMP, nameEPD)
        MsgBox(nb & " EPD positions !")

        End

    End Sub

End Module
