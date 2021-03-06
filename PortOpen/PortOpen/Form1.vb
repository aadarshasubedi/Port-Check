﻿Imports System.Net
Imports System.Text.RegularExpressions
Imports System.IO

Public Class Form1
    Public Function IsProcessRunning(name As String) As Boolean
        'here we're going to get a list of all running processes on the computer
        For Each clsProcess As Process In Process.GetProcesses()
            If clsProcess.ProcessName.StartsWith(name) Then
                'process found so it's running so return true
                Return True
            End If
        Next
        'process not found, return false
        Return False
    End Function
    Public Function ScanPort(ByVal address As String, port As Integer, Optional ByVal timeout As Integer = 500) As Boolean
        Dim client As New Net.Sockets.TcpClient
        Try
            client.BeginConnect(address, port, Nothing, Nothing)
            For i = 0 To timeout
                Threading.Thread.Sleep(1)
                If client.Connected = True Then
                    client.Close()
                    Return True
                End If
            Next
            client.Close()
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
            'If My.Computer.FileSystem.DirectoryExists(TextBox3.Text) Then
            '    MsgBox("Found file location starting")
            'Else
            '    'Else try this
            '    MsgBox("Could not find file location: " & TextBox3.Text)
            'End If
            Dim port1 As Integer = TextBox2.Text
            Dim port2 As Integer = TextBox2.Text
            For i = port1 To port2
                ListBox1.Items.Add("Port " & i & " Connected Status: " & (ScanPort(TextBox1.Text, i)))
            Next
    End Sub

    Private Sub CheckToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CheckToolStripMenuItem.Click
        Timer1.Start()
        If Label1.Visible = False Then
            Label1.Visible = True
        End If
    End Sub

    Private Sub StopCheckToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StopCheckToolStripMenuItem.Click
        Timer1.Stop()
        Timer1.Interval = 5000
        Label1.Text = Timer1.Interval
        If Label1.Visible = True Then
            Label1.Visible = False
        End If
    End Sub

    Private Sub TimeCheckToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TimeCheckToolStripMenuItem.Click
        Timer1.Interval = InputBox("Change check time for each connect")
        If Timer1.Interval < 5000 Then
            Timer1.Interval = 5000
            MsgBox("!Danger! Do not use anything lower than 5 seconds as your check time, new time set to: " & Timer1.Interval)
        End If
        Label1.Text = Timer1.Interval
        If Label1.Visible = False Then
            Label1.Visible = True
        End If
        MsgBox("Time Changed!")
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SaveInfoDataSet1.Table' table. You can move, or remove it, as needed.
        Me.TableTableAdapter.Fill(Me.SaveInfoDataSet1.Table)
        'TODO: This line of code loads data into the 'SaveInfoDataSet1.Table' table. You can move, or remove it, as needed.
        Me.TableTableAdapter.Fill(Me.SaveInfoDataSet1.Table)
        'TODO: This line of code loads data into the 'SaveInfoDataSet1.Table' table. You can move, or remove it, as needed.
        Me.TableTableAdapter.Fill(Me.SaveInfoDataSet1.Table)
        'TODO: This line of code loads data into the 'SaveInfoDataSet1.Table' table. You can move, or remove it, as needed.
        Me.TableTableAdapter.Fill(Me.SaveInfoDataSet1.Table)
        Timer1.Interval = 5000
        Label1.Text = Timer1.Interval
        Label1.Visible = True
        'add a reference to the Microsoft WMI Scripting 1.2 library
        On Error Resume Next
        Dim getip As String = New WebClient().DownloadString("http://automation.whatismyip.com/n09230945.asp")
        Label2.Text = getip
    End Sub

    Private Sub TableBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.TableBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SaveInfoDataSet1)

    End Sub

    Private Sub TableBindingNavigatorSaveItem_Click_1(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.TableBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SaveInfoDataSet1)

    End Sub

    Private Sub TableBindingNavigatorSaveItem_Click_2(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.TableBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SaveInfoDataSet1)

    End Sub

    Private Sub TableBindingNavigatorSaveItem_Click_3(sender As System.Object, e As System.EventArgs) Handles TableBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.TableBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SaveInfoDataSet1)
    End Sub
End Class


