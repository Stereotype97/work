#include "longarifmetic.h"
#include "ui_longarifmetic.h"
#include <QDebug>
#define BASE 10

LongArifmetic::LongArifmetic(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::LongArifmetic)
{
    ui->setupUi(this);

    value = "0";
    secValue = "0";
    signV1 = false;
    signV2 = false;
}

LongArifmetic::~LongArifmetic()
{
    delete ui;
}

string LongArifmetic::spin(string temp){
    string result = temp;
    int j = result.size() - 1;
    for(uni i(0); i < temp.size(); i++){
        result[j] = temp[i];
        j--;
    }
    return result;
}

string LongArifmetic::add (string v1_t, string v2_t){
    uni rank = 0, add_r = 0, tmp = 0;

    bool sign;
    if (!(sign = compare(v1_t, v2_t))) {
        string  temp = v1_t;
        v1_t = v2_t;
        v2_t = temp;
    }


    string v1 = spin(v1_t), v2 = spin(v2_t);

    while ((v1.size()) != (v2.size()))
        v2 += "0";

    string res = "";
    while((rank) < v1.size()){

        tmp = int(v1[rank] - '0') + int(v2[rank] - '0') + add_r;
        if (tmp >= BASE){
            add_r = tmp / BASE;
            tmp %= BASE;
        }
        else add_r = 0;

        if(tmp == 0)
            res += "0";
        else
            res += char(tmp + 48);
        rank++;
    }
    if (add_r != 0)
        res += char(add_r + 48);

    return spin(res);
}

bool LongArifmetic::compare(string v1_t, string v2_t){ // возвращает true если
    // первое число больше второго
    bool check = false;
    if (v1_t.size() > v2_t.size()) check = true;
    else if (v1_t.size() < v2_t.size()) {
        check = false;
    }
    else if (v1_t.size() == v2_t.size()){
        uni i(0);
        while (i < v1_t.size()){
            if (v1_t[i] > v2_t[i]){
                check = true;
                break;
            }
            i++;
        }
    }
    return check;
}

string LongArifmetic::mulOnChar(string v1_t, char num)
{
    uni rank = 0, add_r = 0, tmp = 0;

    string v1 = (v1_t);

    string res = "";
    while((rank) < v1.size()){

        tmp = int(v1[rank] - '0') * int(num - '0') + add_r;
        if (tmp >= BASE){
            add_r = tmp / BASE;
            tmp %= BASE;
        }
        else add_r = 0;

        if(tmp == 0)
            res += "0";
        else
            res += char(tmp + 48);
        rank++;
    }
    if (add_r != 0)
        res += char(add_r + 48);

    return spin(res);


}

string LongArifmetic::module(string v1_t)
{
    if (v1_t[0] != '-'){
        return v1_t;
    }
    else {
        string res = "";
        for(int i(0); i < v1_t.size() - 1; i++){
            res += v1_t[i + 1];
        }
        return res;
    }

}

void LongArifmetic::setPrivateFields(string tmp, string tmp2)
{
    if (tmp[0] == '-'){
        signV1 = true;
    }
    else
        signV1 = false;

    if (tmp2[0] == '-'){
        signV2 = true;
    }
    else
        signV2 = false;

    value = module(tmp);
    secValue = module(tmp2);
}

string LongArifmetic::isCorrect (string temp, bool check){//проверяет корректность
    //выходящих данных
    string res = "", res_n = "";
    uni i (0);
    while (i < temp.size()){
        if(isdigit(temp[i]))
            res += temp[i];
        i++;
    }
    res = spin(res);
    i = 0;
    while(res[i] == '0'){
        i++;
    }

    if (!check) res_n += '-'; // знак возвращаемого значения
    for (uni j(i); j < res.size(); j++){
        res_n += res[j];

    }
    return res_n;
}


string LongArifmetic::subtract (string v1_t, string v2_t){//функция вычитания
    string res = "", temp;
    bool sign;
    if (v1_t == v2_t){
        res = "0";
        return res;
    }
    else
        if (!(sign = compare(v1_t, v2_t))) {
            temp = v1_t;
            v1_t = v2_t;
            v2_t = temp;
        }

    string v1 = spin(v1_t), v2 = spin(v2_t);

    while ((v1.size()) != (v2.size()))
        v2 += "0";

    uni rank = 0, add_r = 0, tmp = 0;

    while (rank < v1.size()){
        if (v1[rank] != '0' && add_r == 1){
            tmp = (uni)(v1[rank] - '0') - add_r;
            add_r = 0;
        }
        else
            if (v1[rank] == '0' && add_r == 1){
                tmp = BASE;

            }
            else tmp = (uni)(v1[rank] - '0');

        tmp -= add_r;

        if (tmp >= uni(v2[rank] - '0'))
            tmp -= uni(v2[rank] - '0');
        else {
            tmp = tmp + BASE - uni(v2[rank] - '0');
            add_r = 1;
        }
        res += char (tmp + 48);
        rank++;
    }
    return isCorrect(res, sign);
}

string LongArifmetic::multiply(string v1_t, string v2_t)
{
    bool sign;
    if (!(sign = compare(v1_t, v2_t))) {
        string temp = v1_t;
        v1_t = v2_t;
        v2_t = temp;
    }

    string v1 = spin(v1_t), v2 = spin(v2_t);

    string res = "0";
    int j = 0;
    for(int i(0); i < v2.size(); i++){
        string tmp = mulOnChar(v1, v2[i]);
        while (j < i){
            tmp +=  "0";
            j++;
        }
        j = 0;
        res = add(res, tmp);
    }

    return res;
}

string LongArifmetic::divide(string, string)
{
    return "";
}

string LongArifmetic::fact(string n)
{
    string res = "1", cnt = "1";


    while(compare(n, cnt)){
        cnt = add(cnt, "1");
        res = multiply(res, cnt);
    }

    return res;
}

string LongArifmetic::pow(string v1, string power)
{
    string res = v1, cnt = "1";

    while(compare(power, cnt)){
        cnt = add(cnt, "1");
        res = multiply(res, v1);
    }
    return res;
}


void LongArifmetic::on_pushButton_clicked()
{

    string first = ui->firstNumber->text().toStdString();
    string second = ui->secondNumber->text().toStdString();
    string res = "";
    setPrivateFields(first, second);

    //////////////////////////////////////////
    //ADDITION
    if(ui->choise_add->isChecked()){
        if (signV1 == false && signV2 == false){
            res = add(value, secValue);
        }
        else
            if (signV1 == false && signV2 == true){
                res = subtract(value, secValue);
            }
            else
                if (signV1 == true && signV2 == false){
                    res = subtract(secValue, value);
                }
                else
                    if (signV1 == true && signV2 == true){
                        res += "-";
                        res += add(value, secValue);
                    }
    }


    /////////////////////////////////////////////
    //SUBSTRACTION
    if(ui->choise_sub->isChecked()){

        if (signV1 == false && signV2 == false){
            res = subtract(value, secValue);
        }
        else
            if (signV1 == false && signV2 == true){
                res = add(value, secValue);
            }
            else
                if (signV1 == true && signV2 == false){
                    res += "-";
                    res += add(value, secValue);
                }
                else
                    if (signV1 == true && signV2 == true){
                        res = subtract(secValue, value);
                    }
    }


    /////////////////////////////////////////
    //MULTIPLING
    if(ui->choise_mul->isChecked()){
        if (signV1 == signV2){
            res = multiply(value, secValue);
        }
        else
        {
            res += "-";
            res += multiply(value, secValue);
        }
    }


    /////////////////////////////////////////
    //DIVIDING
    if(ui->choise_div->isChecked()){

    }


    ///////////////////////////////////
    //FACTORIAL
    if(ui->choise_fact->isChecked()){
        res = fact(value);
    }

    //////////////////////////////////////////
    //POWER
    if(ui->choise_pow->isChecked()){
        res = pow(value, secValue);
    }

    ui->result->setText(QString::fromStdString(res));
}
