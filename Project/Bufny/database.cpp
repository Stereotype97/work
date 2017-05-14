#include "database.h"
static bool create_connect(QSqlDatabase &db){

    if(!db.open()){
        qDebug() << "Cannot open database: " << db.lastError();
        return false;
    }
    //qDebug() << db.connectionName();
    /* QStringList lst = db.tables();
    foreach (QString str, lst) {
        qDebug() << "Table:" << str;
    }*/
    return true;

}

DataBase::DataBase(QObject *parent) : QObject(parent)
{
    connect(this, SIGNAL(good()), this, SLOT(registration()));
    connect(this, SIGNAL(deleteData()), this, SLOT(clearDatabase()));
}

QString DataBase::login()
{
    return _login;
}

void DataBase::setLogin(QString &t)
{
    _login = t;
    emit loginChanged();
}

QString DataBase::password()
{
    return _password;
}

void DataBase::setPassword(QString &t)
{
    _password = t;
    emit passwordChanged();
}

void DataBase::registration()
{
    {QSqlDatabase db = QSqlDatabase::addDatabase("QSQLITE");
        db.database("qt_sql_default_connection", true);
        db.setDatabaseName(QDir::rootPath() + "PROJECT_DB");
        //db.setUserName("Dima");
        //db.setPassword("1234");

        if(!create_connect(db)){
            return;
        }

        QSqlQuery bufny;

        QString str = "CREATE TABLE IF NOT EXISTS bufny ("
                      "id INTEGER PRIMARY KEY NOT NULL,"
                      "name VARCHAR(30) UNIQUE,"
                      "password VARCHAR(20)"
                      ");";

        if(!bufny.exec(str)){
            qDebug() << "Unable to create a table";
        }

        QString str_t("INSERT INTO bufny (name, password)"
                      "VALUES ('%1', '%2');");
        str = str_t.arg(_login)
                .arg(_password);


        if(!bufny.exec(str)){
            qDebug() << "Unable to make insert operation!";
            emit userExist();
        }

        if (!bufny.exec("SELECT * FROM bufny"))
        {
            qDebug() << "Error";
        }
        QSqlRecord rec = bufny.record();
        QString name, password;

        while(bufny.next()){

            //id = bufny.value(rec.indexOf("id")).toInt();
            name = bufny.value(rec.indexOf("name")).toString();
            password = bufny.value(rec.indexOf("password")).toString();

            //qDebug() << id << ' ' << name << "\t" << password;
        }

        db.close();
    }
    QSqlDatabase::removeDatabase("qt_sql_default_connection");
}

void DataBase::clearDatabase()
{
    {QSqlDatabase db = QSqlDatabase::addDatabase("QSQLITE");
            db.database("qt_sql_default_connection", true);
            db.setDatabaseName(QDir::rootPath() + "PROJECT_DB");
            db.setUserName("Dima");
            db.setPassword("1234");

            if(!create_connect(db)){
                return;
            }

            QSqlQuery bufny;
            bufny.exec("DROP TABLE bufny");
            db.close();
    }
    QSqlDatabase::removeDatabase("qt_sql_default_connection");
}


