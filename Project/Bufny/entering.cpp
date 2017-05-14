#include "entering.h"
#include <QDebug>

Entering::Entering(QObject *parent) : QObject(parent)
{

}

QString Entering::login()
{
    return _login;
}

void Entering::setLogin(QString &t)
{
    _login = t;
    emit loginChanged();
}

QString Entering::password()
{
    return _password;
}

void Entering::setPassword(QString &t)
{
    _password = t;
    emit passwordChanged();
}

void Entering::checked()
{
    if(!QFile("C:/PROJECT_DB").exists()){
        qDebug() << "Database is not exists!";
    }
    {
        QSqlDatabase db;
        if (!db.isOpen()){
            db = QSqlDatabase::addDatabase("QSQLITE");
            db.setDatabaseName(QDir::rootPath() + "PROJECT_DB");
        }
        if(!db.open()){
            qDebug() << "Cannot open database: " << db.lastError();
        }

        QSqlQuery bufny;

        if(!bufny.exec("SELECT * FROM bufny;")){
            qDebug() << "Unable to execute query - exiting";
            return;
        }
        //bufny.exec("DROP TABLE bufny");

        QSqlRecord rec = bufny.record();
        QString name, password;

        while(bufny.next()){
            //id = bufny.value(rec.indexOf("id")).toInt();
            name = bufny.value(rec.indexOf("name")).toString();
            password = bufny.value(rec.indexOf("password")).toString();
            if (_password == password)
                checkPassword = true;

            if (_login == name)
                checkLogin = true;
            else
                checkLogin = false;
            if (_password == password)
                checkPassword = true;
            else
                checkPassword = false;
            }

        if (!checkLogin)
        {
            emit userNotExists();
        }
        else
        {
            if (!checkPassword)
            {
            emit passwordIncorrect();
            }
            else
            {
                emit good();
            }
        }

        db.close();
    }
    QSqlDatabase::removeDatabase("qt_sql_default_connection");

}
