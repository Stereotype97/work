#include <QGuiApplication>
#include <QQmlApplicationEngine>
#include "entering.h"
#include "database.h"
#include "record_data.h"

int main(int argc, char *argv[])
{
    QCoreApplication::setAttribute(Qt::AA_EnableHighDpiScaling);
    QGuiApplication app(argc, argv);

    qmlRegisterType<Entering>("Entering", 1, 0, "Entering");
    qmlRegisterType<DataBase>("Database", 1, 0, "Database");
    qmlRegisterType<Record_data>("Record", 1, 0, "Record");

    QQmlApplicationEngine engine;
    engine.load(QUrl(QLatin1String("qrc:/main.qml")));

    return app.exec();
}
