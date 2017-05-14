import QtQuick 2.7
import QtQuick.Controls 2.0

TextField {
    id: current
    placeholderText: "TextField"
    font.pointSize: 12
    horizontalAlignment: Text.AlignHCenter
    width: 250
    height: 40
    background: Rectangle {
        id: back
        implicitWidth: 250
        implicitHeight: 40
        border.width: 1
        color: current.enabled ? "transparent" : "#353637"
        border.color: current.activeFocus ? "#ce93d8" : (current.enabled ? "#bdbebf" : "transparent")
        radius: 15
    }
    state: "good"
    states: [
        State {
            name: "good"
            PropertyChanges {
                target: back
                border.color: current.activeFocus ? "#ce93d8" : (current.enabled ? "#bdbebf" : "transparent")
            }
        },
        State {
            name: "bad"
            PropertyChanges {
                target: back
                border.color: "red"
            }
        }
    ]
    onTextChanged: {
        if (current.text == "")
            current.state = "bad"
        else
            current.state = "good"
    }
    selectByMouse: false

}

