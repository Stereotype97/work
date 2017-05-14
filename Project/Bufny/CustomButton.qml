import QtQuick 2.7
import QtQuick.Controls 2.0

Button {
    id: current
    text: qsTr("Button")
    font.pointSize: 13
    background: Rectangle {
        implicitWidth: 140
        implicitHeight: 50
        opacity: enabled ? 1 : 0.3
        visible: !current.flat || current.down || current.checked || current.highlighted
        color: current.checked || current.highlighted ?
                   (current.visualFocus ? (current.down ? "#599bff" : "#0066ff") : (current.down ? "#585a5c" : "#353637")) :
                   (current.visualFocus ? (current.down ? "#cce0ff" : "#f0f6ff") : (current.down ? "#d0d0d0" : "#e0e0e0"))
        border.color: "#0066ff"
        border.width: current.visualFocus ? 2 : 0
        radius: 15
    }
    width: 140
    height: 50
}
