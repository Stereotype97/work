import QtQuick 2.7
import QtQuick.Controls 2.0
import QtQuick.Controls.Styles 1.4
import QtQuick.Layouts 1.3
import QtQuick.Window 2.2
import QtQuick.Controls 1.4 as QQC
import Record 1.0

ApplicationWindow {
    id: windows
    visible: true
    width: 900
    height: 600
    minimumHeight: 600
    minimumWidth: 838
    //opacity: 0
    PropertyAnimation {
        id: anim
        target: windows
        property: "opacity"
        easing.type: Easing.OutCirc
        from: 0
        to: 1
        duration: 300
        running: true
    }

    Rectangle {
        id:calendar
        border.color: "green"
        height: parent.height
        width: 0.3 * parent.width
        state: "nonPressed"
        FocusScope {
            ColumnLayout {
                width: calendar.width
                height: calendar.height
                //anchors.centerIn: calendar
                //anchors.horizontalCenter: calendar.horizontalCenter
//            Keys.onPressed: {
//                if (event.key === 16777220 || event.key === Qt.Key_Enter)
//                {
//                    rec.comparingRecord = field.text
//                    rec.compareFindingMessage()
//                    showMess.text = ""
//                    showMess.text = rec.findingRecord
//                }
//            }
            QQC.Calendar {
                id: calc
                Layout.alignment: Qt.AlignHCenter | Qt.AlignTop
            }

            Text {
                padding: 10
                text: "Поиск по всем записям"
                font.pixelSize: 20
                Layout.alignment: Qt.AlignHCenter
            }

            CustomTextField {
                id: field
                Layout.alignment: Qt.AlignHCenter | Qt.AlignTop
                //Layout.fillWidth: true
                Layout.preferredWidth: calc.width - 20
                //leftPadding: 15
               //width: calendar.width

                placeholderText: ""
                onTextChanged: {
                    if (field.text == "")
                    {
                        butt.enabled = false
                    }
                    else
                        butt.enabled = true
                }

            }
            CustomButton {
                id: butt
                padding: 5
                text: "Поиск"
                enabled: false
                Layout.alignment: Qt.AlignHCenter | Qt.AlignTop
                onClicked:{
                    rec.comparingRecord = field.text
                    field.text = ""
                    field.state = "good"
                    rec.compareFindingMessage()
                    showMess.text = ""
                    showMess.text = rec.findingRecord
                }

            }
            Flickable {
                anchors.top: butt.bottom
                width: 220
                height: 180
                anchors.horizontalCenter: parent.horizontalCenter
                anchors.topMargin: 10
                flickableDirection: Flickable.VerticalFlick
                boundsBehavior: Flickable.StopAtBounds
                TextArea.flickable: TextArea {
                    id:showMess
                    width: parent.width
                    height: parent.height
                    wrapMode: TextArea.Wrap
                    readOnly: true
                    font.family: "Arial"
                    font.bold: true
                    font.italic: true
                    font.pointSize: 12
                    background: Rectangle {
                        anchors.fill: parent
                        antialiasing: true
                        color: "#E3E3E3"
                        radius: 20
                    }
                    color: "#A68A73"
                }


                ScrollBar.vertical: ScrollBar
                {
                }
        }
        }
}


        states: [
            State {
                name: "nonPressed"
                PropertyChanges {
                    target: calendar
                    opacity: 0
                    x: -0.3 * parent.width
                }
                PropertyChanges {
                    target: callButton
                    anchors.leftMargin: 5
                    width: 40
                    height: 220
                    radius: 20
                }
                PropertyChanges {
                    target: text
                    text: qsTr("К\nа\nл\nе\nн\nд\nа\nр\nь")
                    font.pointSize: 13
                }
            },
            State {
                name: "Pressed"
                PropertyChanges {
                    target: calendar
                    opacity: 1
                    x: 0
                }
                PropertyChanges {
                    target: callButton
                    anchors.leftMargin: 15
                    width: 30
                    height: 30
                    radius: 15
                }
                PropertyChanges {
                    target: text
                    text: qsTr("К")
                    font.pointSize: 13
                }
            }

        ]
        transitions:
            Transition {
            PropertyAnimation {
                properties: "x, opacity"
                easing.type: Easing.InOutQuad;
                duration: 500
            }
            PropertyAnimation {
                target: callButton
                properties: "width, height, radius, anchors.leftMargin"
                easing.type: Easing.InOutQuad;
                duration: 500
            }
            PropertyAnimation {
                target: text
                easing.type: Easing.InExpo
                properties: "opacity"
                from: 0
                to: 1
                duration: 600
            }
        }
    }

    Rectangle {
        id: callButton
        anchors.left: calendar.right
        anchors.leftMargin: 15
        y: calendar.height / 2 - height / 2
        color: "#ffa000"
        Text {
            id: text
            anchors.centerIn: parent
        }
        MouseArea {
            anchors.fill: parent
            onClicked: {
                calendar.state = (calendar.state == "nonPressed" ? "Pressed" : "nonPressed")
            }
        }
    }


    GridLayout {
        id: grid
        columns: 1//2
        rows: 1//2
        height: parent.height
        width: (windows.width - calendar.x) / 2
        x: callButton.x + callButton.width + 30


        Flickable {
            id: flickable

            Layout.fillWidth: true
            Layout.fillHeight: true
            flickableDirection: Flickable.VerticalFlick
            boundsBehavior: Flickable.StopAtBounds
            TextArea.flickable: TextArea {
                id: textArr
                width: grid.width
                height: parent.height
                wrapMode: TextArea.Wrap
                placeholderText: "\tРасскажите, как проходит Ваш день"
                font.family: "Arial"
                font.bold: true
                font.italic: true
                font.pointSize: 12
                background: Rectangle {
                    anchors.fill: parent
                    antialiasing: true
                    color: "#E3E3E3"
                    radius: 20
                }
                color: "#A68A73"
                onTextChanged: {
                    if (textArr.text == "")
                        save.enabled = false
                    else
                        save.enabled = true
                }
            }


            ScrollBar.vertical: ScrollBar
            {
            id: scroll
        }
    }


    Record {
        id: rec
    }
    CustomButton {
        id: save
        width: Layout.width / 3
        Layout.alignment: Qt.AlignRight
        text: qsTr("Сохранить")
        enabled: false
        onClicked: {
            rec.record = textArr.text
            textArr.text = ""
        }

    }
    CustomButton {
        width: Layout.width / 3
//        anchors.left: save.right
        Layout.alignment: Qt.AlignLeft
        anchors.top: save.top
        text: qsTr("Показать все")
        onClicked: {
            rec.makeShowingRecord()
            show.visible = true
            textShow.text = ""
            textShow.text = rec.showingRecord
        }

    }

    Window {
        id: show
        title: "Все записи"
        maximumWidth: 500
        maximumHeight: 400
        minimumWidth: 500
        minimumHeight: 400
        visible: false
        Flickable {
            anchors.fill: parent
            flickableDirection: Flickable.VerticalFlick
            boundsBehavior: Flickable.StopAtBounds
            TextArea.flickable: TextArea {
                id: textShow
                width: parent.width
                height: parent.height
                wrapMode: TextArea.Wrap
                font.family: "Arial"
                font.bold: true
                font.italic: true
                font.pointSize: 12
                background: Rectangle {
                    anchors.fill: parent
                    antialiasing: true
                    color: "#E3E3E3"
                    radius: 20
                }
                color: "#A68A73"
            }


            ScrollBar.vertical: ScrollBar
            {
            }
    }
    }
}

}

