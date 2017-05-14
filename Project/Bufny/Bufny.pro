QT += qml quick sql

CONFIG += c++11

SOURCES += main.cpp \
    entering.cpp \
    database.cpp \
    record_data.cpp

RESOURCES += qml.qrc

RC_ICONS = favicon.ico

# Additional import path used to resolve QML modules in Qt Creator's code model
QML_IMPORT_PATH =

# Default rules for deployment.
qnx: target.path = /tmp/$${TARGET}/bin
else: unix:!android: target.path = /opt/$${TARGET}/bin
!isEmpty(target.path): INSTALLS += target

HEADERS += \
    entering.h \
    database.h \
    record_data.h

DISTFILES += \
    favicon.ico
