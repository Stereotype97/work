import QtQuick 2.7
import QtQuick.Controls 2.0
import QtQuick.Layouts 1.0
import Entering 1.0

Item {
    id: appWindow
    EnterWind {
      id: en
    }

    Connections {
        target: en
        onGoodQML: process()
    }
   //WindowApp{}
    function process() {
        en.close();
        var component = Qt.createComponent("WindowApp.qml");
        var sprite;
        function finishCreation() {
            if (component.status === Component.Ready) {
                sprite = component.createObject(appWindow);
                if (sprite === null) {

                    console.log("Error creating object");
                }
            } else if (component.status === Component.Error) {

                console.log("Error loading component:", component.errorString());
            }
        }
        if (component.status === Component.Ready)
            finishCreation();
        else
            component.statusChanged.connect(finishCreation);

    }
}
