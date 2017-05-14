import QtQuick 2.7
import QtQuick.Controls 2.0
import QtQuick.Dialogs 1.2
import QtQuick.Layouts 1.0
import QtQuick.Window 2.2
import Entering 1.0
import Database 1.0

ApplicationWindow {
    id: wind
    visible: true
    minimumHeight: 600
    minimumWidth: 700
    maximumHeight: 600
    maximumWidth: 700

    signal goodQML()

    FocusScope {
        id: auth
        anchors.fill: parent
        focus: true
        Keys.onPressed: {
            if (event.key === 16777220 || event.key === Qt.Key_Enter)
                m.checked();
        }

        Entering {
            id: m
            onGood: {
                wind.goodQML()
            }
            onUserNotExists: {
                error.open()
                error.text = qsTr("Такой пользователь не зарегистрирован")
                defaultStateAuth()
                login.focus = true
            }
            onPasswordIncorrect: {
                error.open()
                error.text = qsTr("Не правильный пароль")
                password.text = ""
                password.state = "good"
                password.focus = true
            }
        }

        Column {
            id: col
            anchors.fill: parent
            spacing: 15
            topPadding: 30
            Image {
                id: icon
                source: "/source/Bufny.jpg"
                x: parent.width/2 - width/2
            }

            CustomTextField {
                id: login
                focus: true
                x: parent.width/2 - width/2
                placeholderText: qsTr("Логин")
                onEditingFinished: {
                    m.login = login.text
                }

            }

            CustomTextField {
                id: password
                x: parent.width/2 - width/2
                placeholderText: qsTr("Пароль")
                echoMode: TextInput.Password
                onEditingFinished: {
                    m.password = password.text
                }

            }

            CustomButton {
                id: enter
                y: parent.height - 90
                x: parent.width/2 - width/2
                text: qsTr("Войти")
                onClicked: {
                    if (login.text == "")
                        login.state = "bad"
                    else
                    {
                        if (password.text == "")
                        {
                            password.state = "bad"
                        }
                        else
                            m.checked();
                    }
                }
            }
        }

        Rectangle {
            id: reg
            width: 40
            height: 40
            x: wind.width - width - y
            y: 30
            color: "#be6f6f"
            radius: 20
            property alias text_: t.text
            property alias fsize: t.font.pointSize
            states: [
                State {
                    name: "unhovered"
                    PropertyChanges {
                        target: reg
                        width: 40
                        text_: qsTr("Р")
                        fsize: 16

                    }
                },
                State {
                    name: "hovered"
                    PropertyChanges {
                        target: reg
                        width: 120
                        text_: qsTr("Регистрация")
                        fsize: 13
                    }
                }

            ]
            transitions:
                Transition {
                NumberAnimation {
                    properties: "width";
                    easing.type: Easing.InOutQuad;
                    duration: 300
                }
                PropertyAnimation {
                    target: t
                    property: "opacity"
                    from: 0
                    to: 1
                    easing.type: Easing.InExpo
                    duration: 400
                }
            }
            Text {
                id: t
                font.pointSize: 16
                anchors.centerIn: parent
                text: qsTr("Р");
            }

            MouseArea{
                id: mouse
                anchors.rightMargin: 1
                anchors.bottomMargin: 0
                anchors.leftMargin: -1
                anchors.topMargin: 0
                anchors.fill: parent
                hoverEnabled: true
                onEntered: {
                    reg.state = "hovered"
                }
                onExited: {
                    reg.state = "unhovered"
                }
                onClicked: {
                    regis.visible = true
                    defaultStateRegis()
                    defaultStateAuth()
                }
            }

        }
    }
    MessageDialog {
        id: error
        modality: Qt.NonModal
        icon: StandardIcon.Warning
    }

    Window {
        id: regis
        title: qsTr("Регистрация")
        minimumHeight: 280
        minimumWidth: 280
        maximumHeight: 280
        maximumWidth: 280
        modality: Qt.WindowModal
        Database {
            id:data
            onUserExist: userExist.open()
        }
        FocusScope {
            id: registration
            anchors.fill: parent
            Keys.onPressed: {
                if (event.key === 16777220 || event.key === Qt.Key_Enter)
                    checked();
            }
            Label {
                anchors.horizontalCenter: parent.horizontalCenter
                font.pointSize: 12
                text: "Здесь Вы можете зарегистрироваться\nв программе"
            }
            Column {
                y: parent.height / 2 - height / 1.5
                x: parent.width / 2 - width / 2
                spacing: 10
                CustomTextField {
                    id: login_
                    placeholderText: qsTr("Логин")
                }
                CustomTextField {
                    id: password_
                    echoMode: TextInput.Password
                    placeholderText: qsTr("Пароль")
                    /*onTextChanged: {
                        if (password_.text != password_2.text)
                            password_2.state = "bad"
                    }*/
                }
                CustomTextField {
                    id: password_2
                    echoMode: TextInput.Password
                    placeholderText: qsTr("Повторите пароль")
                    onTextChanged: {
                        if (password_.text != password_2.text)
                            password_2.state = "bad"
                        else if (password_.text == "")
                        {
                            password_.state = "bad"
                            password_2.state = "bad"
                        }
                        else {
                            password_2.state = "good"
                            password_.state = "good"
                        }

                    }
                }
            }

            Row {
                anchors.bottom: parent.bottom
                spacing: 20
                padding: 15
                width: parent.width
                CustomButton {
                    text: qsTr("Регистрация")
                    width: parent.width / 2 - parent.spacing / 2 - parent.padding
                    onClicked: checked()
                }
                CustomButton {
                    text: qsTr("Удалить базу!")
                    width: parent.width / 2 - parent.spacing / 2 - parent.padding
                    onClicked: data.deleteData();
                }
                CustomButton {
                    text: qsTr("Отмена")
                    width: parent.width / 2 - parent.spacing / 2 - parent.padding
                    onClicked: regis.close()
                }

            }
        }
        MessageDialog {
            id: userExist
            text: "Такой пользователь уже существует!"
        }
    }
    function defaultStateRegis()
    {
        login_.text = ""
        password_.text = ""
        password_2.text = ""
        login_.state = "good"
        password_.state = "good"
        password_2.state = "good"
        registration.focus = false

    }
    function defaultStateAuth()
    {
        login.text = ""
        password.text = ""
        login.state = "good"
        password.state = "good"
        login.focus = true

    }
    function checked ()
    {
        if (login_.text == "")
            login_.state = "bad"
        else
        {
            data.login = login_.text
            if (password_.text == "" || password_2.text == "" || password_.text != password_2.text)
            {
                password_.state = "bad"
                password_2.state = "bad"
            }
            else
            {
                data.password = password_.text
                data.good()
                regis.close()
            }
        }
    }

}
