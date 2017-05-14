    #include "record_data.h"

    QSqlDatabase db;

    Record_data::Record_data(QObject *parent):QObject(parent)
    {
        _record = "";
        _showingRecord = "";
        _comparingRecord = "";
        _findingRecord = "Такой записи не найдено!";
        connect(this, SIGNAL(recordChanged()), this, SLOT(addRecord()));
    }

    QString Record_data::record(){
        return _record;
    }

    QString Record_data::showingRecord(){
        return _showingRecord;
    }

    QString Record_data::comparingRecord(){
        return _comparingRecord;
    }

    QString Record_data::findingRecord(){
        return _findingRecord;
    }

    void Record_data::databaseOpen(){
        if(!QFile(QDir::rootPath() + "PROJECT_DB").exists()){
            qDebug() << "Database is not exists!";
        }
        if (!db.isOpen()){
            db = QSqlDatabase::addDatabase("QSQLITE");
            //db.database("qt_sql_default_connection", true);
            db.setDatabaseName("C:/PROJECT_DB");
        }
        if(!db.open()){
            qDebug() << "Cannot open database: " << db.lastError();
        }
    }

    void Record_data::setRecord(QString &t)
    {
        _record = t;
        emit recordChanged();
    }

    void Record_data::setShowingRecord(QString &t)
    {
        _showingRecord = t;
        emit showingRecordChanged();
    }

    void Record_data::setComparingRecord(QString &t)
    {
        _comparingRecord = t;
        emit comparingRecordChanged();
    }

    void Record_data::setFindingRecord(QString &t)
    {
        _findingRecord = t;
        emit findingRecordChanged();
    }



    void Record_data::addRecord()
    {
        {
            databaseOpen();

            QSqlQuery textRec;

            QString str = "CREATE TABLE IF NOT EXISTS text_rec ("
                          "id INTEGER PRIMARY KEY NOT NULL,"
                    // "user VARCHAR(30),"
                    "message text"
                    ");";

            if(!textRec.exec(str)){
                qDebug() << "Unable to create a table";
            }

            QString str_t("INSERT INTO text_rec (message)"
                          "VALUES ('%1');");
            str = str_t.arg(_record);


            if(!textRec.exec(str)){
                qDebug() << "Unable to make insert operation!";
                //emit userExist();
            }
            db.close();
        }
        QSqlDatabase::removeDatabase("qt_sql_default_connection");
    }

    void Record_data::makeShowingRecord()
    {
        {
            databaseOpen();

            QSqlQuery textRec;

            if(!textRec.exec("SELECT * FROM text_rec;")){
                qDebug() << "Unable to execute query - exiting";
                return;
            }

            QSqlRecord r = textRec.record();
            QString oneMess = "";
            _showingRecord = "";

            while(textRec.next()){
                oneMess = textRec.value(r.indexOf("message")).toString();
                _showingRecord += oneMess + "\n"
                        +"*******************************************************************************" + "\n";
            }

            //textRec.exec("DROP TABLE text_rec");
            db.close();
        }
        QSqlDatabase::removeDatabase("qt_sql_default_connection");
    }

    void Record_data::compareFindingMessage()
    {
        {
            databaseOpen();

            QSqlQuery textRec;

            if(!textRec.exec("SELECT * FROM text_rec;")){
                qDebug() << "Unable to execute query - exiting";
                return;
            }

            QSqlRecord r = textRec.record();

            _findingRecord = "";

            if (_comparingRecord != "" && _comparingRecord != " "){
            QString oneMess = "", temp = _comparingRecord;

            while(textRec.next()){
                oneMess = textRec.value(r.indexOf("message")).toString();

                if(oneMess.contains(temp, Qt::CaseInsensitive)){
                    _findingRecord += oneMess + "\n" +"*********************************" + "\n";
                }
            }
            }
            else
                if (_comparingRecord == " ")
                    _findingRecord = "Искать пробел в записях - не самая лучшая мысль)!";

            if (_findingRecord.isEmpty()){
                _findingRecord = "Такой записи нет!";
            }
            db.close();
        }
        QSqlDatabase::removeDatabase("qt_sql_default_connection");
    }
