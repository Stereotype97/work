#ifndef ENTERING_H
#define ENTERING_H
#include <QtSql>

#include <QObject>

class Entering : public QObject
{
    Q_OBJECT

    Q_PROPERTY(QString login READ login WRITE setLogin NOTIFY loginChanged)
    Q_PROPERTY(QString password READ password WRITE setPassword NOTIFY passwordChanged)

public:
    explicit Entering(QObject *parent = 0);

    QString login();
    void setLogin(QString &t);
    QString password();
    void setPassword(QString &t);
    Q_INVOKABLE void checked();

signals:
    void loginChanged();
    void passwordChanged();
    void good();
    void passwordIncorrect();
    void userNotExists();

private:
    QString _login;
    QString _password;
    bool checkLogin = false, checkPassword = false;

public slots:
};

#endif // ENTERING_H
