#ifndef DATABASE_H
#define DATABASE_H

#include <QObject>
#include <QtSql>
#include <QSqlQuery>
#include <QSqlError>
#include <QSqlDatabase>

#include <QFile>
#include <QDate>
#include <QDebug>
#include <QDir>

class DataBase : public QObject
{
    Q_OBJECT
    Q_PROPERTY(QString login READ login WRITE setLogin NOTIFY loginChanged)
    Q_PROPERTY(QString password READ password WRITE setPassword NOTIFY passwordChanged)

private:
    QString _login;
    QString _password;

public:
    explicit DataBase(QObject *parent = 0);
    QString login();
    void setLogin(QString &t);
    QString password();
    void setPassword(QString &t);

signals:
    void loginChanged();
    void passwordChanged();
    void good();
    void deleteData();
    void userExist();

public slots:
    void registration();
    void clearDatabase();
};

#endif // DATABASE_H
