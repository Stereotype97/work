/*
    @authors:   Evgeniy Fastovets
                Dmytro Skorobogatskii
    @firstRelease: 21.12.2016
  */
#ifndef RECORD_DATA_H
#define RECORD_DATA_H
#include <QString>
#include <QObject>
#include <QtSql>
#include <QSqlQuery>
#include <QSqlError>
#include <QSqlDatabase>

class Record_data : public QObject
{
      Q_OBJECT
    Q_PROPERTY(QString record READ record WRITE setRecord NOTIFY recordChanged)
    Q_PROPERTY(QString showingRecord READ showingRecord WRITE setShowingRecord NOTIFY showingRecordChanged)
    Q_PROPERTY(QString comparingRecord READ comparingRecord WRITE setComparingRecord NOTIFY comparingRecordChanged)
    Q_PROPERTY(QString findingRecord READ findingRecord WRITE setFindingRecord NOTIFY findingRecordChanged)
public:
    explicit Record_data(QObject *parent = 0);

    QString record();
    QString showingRecord();
    QString comparingRecord();
    QString findingRecord();
    void setRecord(QString &);
    void setShowingRecord(QString &);
    void setComparingRecord(QString &);
    void setFindingRecord(QString &);

private:
    QString _record;
    QString _showingRecord;
    QString _comparingRecord;
    QString _findingRecord;

    void databaseOpen();

signals:
     void recordChanged();
     void showingRecordChanged();
     void comparingRecordChanged();
     void findingRecordChanged();

public slots:
     void addRecord();
     void makeShowingRecord();
     void compareFindingMessage();
};



#endif // RECORD_DATA_H
