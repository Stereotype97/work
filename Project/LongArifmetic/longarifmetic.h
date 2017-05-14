#ifndef LONGARIFMETIC_H
#define LONGARIFMETIC_H

#include <QMainWindow>
#include <string>

using namespace  std;
typedef unsigned int uni;

namespace Ui {
class LongArifmetic;
}

class LongArifmetic : public QMainWindow
{
    Q_OBJECT

private:
      string value;
      string secValue;
      bool signV1;
      bool signV2;
      Ui::LongArifmetic *ui;
public:
    explicit LongArifmetic(QWidget *parent = 0);
    ~LongArifmetic();

    string add(string, string);          // операция прибавления
    string subtract(string, string);     // операция вычитания
    string multiply (string, string);    // операция умножения
    string divide (string, string);      // операция деления

    string fact(string);
    string pow(string, string);


private slots:
    void on_pushButton_clicked();

protected:

    string spin(string);
    string isCorrect(string, bool);
    bool compare(string, string);
    string mulOnChar(string, char);
    string module(string);

    void setPrivateFields(string, string);
};

#endif // LONGARIFMETIC_H
