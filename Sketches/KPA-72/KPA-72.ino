////////////////////////////////////////////////////////////////////////////////////
////////                                                                    ////////
////                                                                            ////
//        БИБЛИОТЕКИ                                                              //
////                                                                            ////
////////                                                                    ////////
////////////////////////////////////////////////////////////////////////////////////

////                                                                            ////
//        БИБЛИОТЕКИ ЭНКОДЕРОВ                                                    //
////                                                                            ////

#include <ACE128.h> // Подключение библиотеки энкодера
#include <ACE128map87654321.h> // Карта пинов 87654321
////////////////////////////////////////////////////////////////////////////////////
////////                                                                    ////////
////                                                                            ////
//        ПЕРЕМЕННЫЕ                                                              //
////                                                                            ////
////////                                                                    ////////
////////////////////////////////////////////////////////////////////////////////////

////                                                                            ////
//        ПЕРЕМЕННЫЕ ТРЕХПОЗИЦИОННЫХ ТУМБЛЕРОВ                                    //
////                                                                            ////

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ТУМБЛЕРОВ!
#define TOGGNUM 2

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ТУМБЛЕРОВ!
const byte toggIn1[] = {48, 47}; // Пины тумблеров поз.1
bool toggLog1[] = {false, false}; // Переменная для определения изменений в положении тумблера

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ТУМБЛЕРОВ!
const byte toggIn2[] = {50, 49}; // Пины тумблеров поз.2
bool toggLog2[] = {false, false}; // Переменная для определения изменений в положении тумблера

////                                                                            ////
//        ПЕРЕМЕННЫЕ ПРЕДОХРАНИТЕЛЕЙ                                              //
////                                                                            ////

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ПРЕДОХРАНИТЕЛЕЙ!
#define FUSENUM 4

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ПРЕДОХРАНИТЕЛЕЙ!
const byte fuseIn[] = {14, 15, 16, 17}; // Пины предохранителей
bool fuseLog[] = {false, false, false, false}; // Переменная для определения изменений в положении предохранителей

////                                                                            ////
//        ПЕРЕМЕННЫЕ РАЗЪЕМОВ                                                     //
////                                                                            ////

#define CONNDELAY0 50 // Время между двумя изменениями
#define CONNDELAY1 4000 // Время между двумя изменениями (для закручивающихся)

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО РАЗЪЕМОВ!
#define CONNNUM 4 // Количество разъемов

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО РАЗЪЕМОВ!
int connType[CONNNUM] = {1, 1, 1, 1}; // Тип разъема
int connDelay[CONNNUM] = {0, 0, 0, 0}; // Время между двумя изменениями

const byte connPin[CONNNUM] = {2, 3, 4, 5}; // Пины разъемов

boolean connPos[CONNNUM] = {false, false, false, false}; // Положение разъемов

unsigned long connTime[CONNNUM] = {0, 0, 0, 0}; // Момент времени изменения положения разъемов

////                                                                            ////
//        ПЕРЕМЕННЫЕ ПОТЕНЦИОМЕТРОВ                                               //
////                                                                            ////

#define POTERROR 30 // Шум в значении потенциометра

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ПОТЕНЦИОМЕТРОВ!
#define POTNUM 5
// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ПОТЕНЦИОМЕТРОВ!
const byte potPin[POTNUM] = {A0, A1, A2, A4, A3}; // Пины потенциометров

int potPos[POTNUM] = {0, 0, 0, 0, 0}; // Положение потенциометра
int oldPotPos[POTNUM] = {0, 0, 0, 0, 0}; // Предыдущее положение потенциометра
int truePotPos[POTNUM] = {0, 0, 0, 0, 0}; // Округленное положение потенциометра
int oldTruePotPos[POTNUM] = {0, 0, 0, 0, 0}; // Предыдущее округленное положение потенциометра

////                                                                            ////
//        ПЕРЕМЕННЫЕ СВЕТОДИОДОВ                                                  //
////                                                                            ////

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО СВЕТОДИОДОВ!
#define DIODNUM 1

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО СВЕТОДИОДОВ!
const byte diodIn[] = {18}; // Пины светодиодов
bool diodLog[] = {false}; // Переменная для определения изменений в положении светодиодов

///////////////////////Кнопки и тумблеры 2////////////////////////////
////2 позиции////
// Задержка
#define BUTTDELAY 50
// Количество кнопок
#define BUTTNUM 12
// Пины кнопок
const byte buttPin[BUTTNUM] = {24, 26, 28, 36, 38, 40, 32, 34, 52, 42, 44, 46};
// Положение кнопки
boolean buttPos[BUTTNUM] = {false, false, false, false, false, false, false, false, false, false, false, false};
// Реверс кнопки
boolean buttRev[BUTTNUM] = {false, false, false, false, false, false, false, false, false, false, false, false};
// Момент времени изменения положения кнопки
unsigned long buttTime[BUTTNUM] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

////                                                                            ////
//        ПЕРЕМЕННЫЕ ЭНКОДЕРОВ                                                    //
////                                                                            ////

//#define ENCSETUP // Раскомментировать для настройки

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
#define ENCNUM 14 // Количество энкодеров

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
const byte encoderAddress[ENCNUM] = {0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D}; // Адреса энкодеров

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
ACE128 enc0((uint8_t)encoderAddress[0], (uint8_t*)encoderMap_87654321); // Адрес и карта энкодера
ACE128 enc1((uint8_t)encoderAddress[1], (uint8_t*)encoderMap_87654321);
ACE128 enc2((uint8_t)encoderAddress[2], (uint8_t*)encoderMap_87654321);
ACE128 enc3((uint8_t)encoderAddress[3], (uint8_t*)encoderMap_87654321);
ACE128 enc4((uint8_t)encoderAddress[4], (uint8_t*)encoderMap_87654321);
ACE128 enc5((uint8_t)encoderAddress[5], (uint8_t*)encoderMap_87654321);
ACE128 enc6((uint8_t)encoderAddress[6], (uint8_t*)encoderMap_87654321); // Адрес и карта энкодера
ACE128 enc7((uint8_t)encoderAddress[7], (uint8_t*)encoderMap_87654321);
ACE128 enc8((uint8_t)encoderAddress[8], (uint8_t*)encoderMap_87654321);
ACE128 enc9((uint8_t)encoderAddress[9], (uint8_t*)encoderMap_87654321);
ACE128 enc10((uint8_t)encoderAddress[10], (uint8_t*)encoderMap_87654321);
ACE128 enc11((uint8_t)encoderAddress[11], (uint8_t*)encoderMap_87654321);
ACE128 enc12((uint8_t)encoderAddress[12], (uint8_t*)encoderMap_87654321);
ACE128 enc13((uint8_t)encoderAddress[13], (uint8_t*)encoderMap_87654321);

uint8_t rawPos[ENCNUM] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; // Текущее положение энкодера
uint8_t oldRawPos[ENCNUM] = {127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127}; // Предыдущее положение энкодера

#ifndef ENCSETUP
int encType[ENCNUM] = {3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; // Тип энкодера
int rawBorder[ENCNUM][2] = {{102, 102}, {36, 36}, {82, 82}, {85, 43}, {100, 27}, {29, 92}, {126, 67}, {51, 9}, {37, 88}, {100, 25}, {76, 55}, {74, 53}, {126, 62}, {125, 62}};
// Границы положений энкодера
int encBorder[ENCNUM][2] = {{0, 100}, {0, 100}, {0, 100}, {0, 8}, {0, 5}, {0, 6}, {0, 6}, {0, 8}, {0, 5}, {0, 5}, {0, 10}, {0, 10}, {0, 6}, {0, 6}};
// Границы положений энкодера по шкале

double encPoint[ENCNUM] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; //
double encPos[ENCNUM] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; // Положение энкодера по шкале
double oldEncPos[ENCNUM] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; // Предыдущее положение энкодера по шкале
double rawNorm[ENCNUM] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
#endif

////                                                                            ////
//        ОБЩИЕ ПЕРЕМЕННЫЕ                                                        //
////                                                                            ////

//#define DEBUG // Раскомментировать для отладки

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭЛЕМЕНТОВ!
#define ELEMNUM 50

String str = "";
int i = 0;
int n = 0;
unsigned long t = 0;
boolean checkElem = false;

void setup() {

  ////////////////////////////////////////////////////////////////////////////////////
  ////////                                                                    ////////
  ////                                                                            ////
  //        НАСТРОЙКА                                                               //
  ////                                                                            ////
  ////////                                                                    ////////
  ////////////////////////////////////////////////////////////////////////////////////

  Serial.begin(115200); // Инициализация порта для работы с ПК
  Serial.println("KPA-72");
  Serial.println("complite");

  ////                                                                            ////
  //        НАСТРОЙКИ ТРЕХПОЗИЦИОННЫХ ТУМБЛЕРОВ                                     //
  ////                                                                            ////

  for (int i = 0; i < TOGGNUM; i++) {
    pinMode(toggIn1[i], INPUT); // Настройка пина на вход
    digitalWrite(toggIn1[i], HIGH); // Подтяжка пина к питанию

    pinMode(toggIn2[i], INPUT);
    digitalWrite(toggIn2[i], HIGH);
  }

  for (int i = 0; i < TOGGNUM; i++) { // Опрос тумблеров
    if (digitalRead(toggIn1[i]) == HIGH && digitalRead(toggIn2[i]) == HIGH) {
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("0");
      
    }
    else if (digitalRead(toggIn1[i]) == LOW) {
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("1");
      toggLog1[i] = true;
    }
    else if (digitalRead(toggIn2[i]) == LOW) {
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("2");
      toggLog2[i] = true;
    }
  }

  ////                                                                            ////
  //        НАСТРОЙКИ ПРЕДОХРАНИТЕЛЕЙ                                               //
  ////                                                                            ////

  for (int i = 0; i < FUSENUM; i++) {
    pinMode(fuseIn[i], INPUT); // Настройка пина на вход
    digitalWrite(fuseIn[i], HIGH); // Подтяжка пина к питанию
  }

  for (int i = 0; i < FUSENUM; i++) { // Опрос предохранителей
    if (digitalRead(fuseIn[i]) == HIGH) {
      Serial.print("f");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("0");
    }
    else if (digitalRead(fuseIn[i]) == LOW) {
      Serial.print("f");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("1");
      fuseLog[i] = true;
    }
  }

  ////                                                                            ////
  //        НАСТРОЙКИ РАЗЪЕМОВ                                                      //
  ////                                                                            ////

  for (i = 0; i < CONNNUM; i++) {
    pinMode(connPin[i], INPUT); // Настройка пина на вход
    digitalWrite(connPin[i], HIGH); // Подтяжка пина к питанию

    if (connType[i] == 0) {
      connDelay[i] = CONNDELAY0;
    }
    else if (connType[i] == 1) {
      connDelay[i] = CONNDELAY1;
    }
  }

  for (i = 0; i < CONNNUM; i++) { // Опрос разъемов
    if (digitalRead(connPin[i]) == HIGH) {
      Serial.print("c");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("0");
    }
    else if (digitalRead(connPin[i]) == LOW) {
      Serial.print("c");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("1");
      connPos[i] = true;
    }
    n++;
  }

  ////                                                                            ////
  //        НАСТРОЙКИ ПОТЕНЦИОМЕТРОВ                                                //
  ////                                                                            ////

  for (i = 0; i < POTNUM; i++) { // Опрос потенциометров
    potPos[i] = analogRead(potPin[i]);
    oldPotPos[i] = potPos[i];
    truePotPos[i] = potPos[i] / POTERROR * POTERROR;
    if (truePotPos[i] > 1000) {
      truePotPos[i] = 1000;
    }
    oldTruePotPos[i] = truePotPos[i];
    Serial.print("p");
    Serial.print("#");
    Serial.print(i);
    Serial.print("#");
    Serial.println(truePotPos[i]);
    
    n++;
  }

  //        НАСТРОЙКИ КНОПОК                                                        //
  ////                                                                            ////
  for (i = 0; i < BUTTNUM; i++) {
    pinMode(buttPin[i], INPUT); // Настройка пина на вход
    digitalWrite(buttPin[i], HIGH); // Подтяжка пина к питанию
  }
  for (i = 0; i < BUTTNUM; i++) { // Опрос кнопок
    if (buttRev[i] == false) {
      if (digitalRead(buttPin[i]) == HIGH) {
        Serial.print("b");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("0");
      }
      else if (digitalRead(buttPin[i]) == LOW) {
        Serial.print("b");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("1");
        buttPos[i] = true;
      }
    }
    else {
      if (digitalRead(buttPin[i]) == HIGH) {
        Serial.print("b");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("1");
        buttPos[i] = true;
      }
      else if (digitalRead(buttPin[i]) == LOW) {
        Serial.print("b");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("0");
      }
    }
    n++;
  }

  ////                                                                            ////
  //        НАСТРОЙКА ЭНКОДЕРОВ                                                     //
  ////                                                                            ////

#ifdef ENCODERSETUP
  Serial.println("ENCODERSETUP DEFINED");
#endif

  // ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
  enc0.begin(); // Инициализация работы энкодера
  enc1.begin();
  enc2.begin();
  enc3.begin();
  enc4.begin();
  enc5.begin();
  enc6.begin();
  enc7.begin();
  enc8.begin();
  enc9.begin();
  enc10.begin();
  enc11.begin();
  enc12.begin();
  enc13.begin();

  // ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
  rawPos[0] = enc0.rawPos(); // Опрос энкодера
  rawPos[1] = enc1.rawPos();
  rawPos[2] = enc2.rawPos();
  rawPos[3] = enc3.rawPos();
  rawPos[4] = enc4.rawPos();
  rawPos[5] = enc5.rawPos();
  rawPos[6] = enc6.rawPos();
  rawPos[7] = enc7.rawPos();
  rawPos[8] = enc8.rawPos();
  rawPos[9] = enc9.rawPos();
  rawPos[10] = enc10.rawPos();
  rawPos[11] = enc11.rawPos();
  rawPos[12] = enc12.rawPos();
  rawPos[13] = enc13.rawPos();


#ifdef ENCSETUP
  for (i = 0; i < ENCNUM; i++) { // Вывод текущего положения энкодера
    oldRawPos[i] = rawPos[i];
    Serial.print("e");
    Serial.print("#");
    Serial.print(i);
    Serial.print("#");
    Serial.println(rawPos[i]);
  }
#endif

#ifndef ENCSETUP
  for (i = 0; i < ENCNUM; i++) { // Вывод в порт ПК текущего состояния энкодера
    oldRawPos[i] = rawPos[i];
    if (rawPos[i] == 255) {
#ifdef DEBUG
      Serial.print("e");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("ERROR");
#endif
      encPos[i] = encBorder[i][0];
    }
    else {
      if (rawBorder[i][0] < rawBorder[i][1]) {
        rawNorm[i] = rawBorder[i][1] - rawBorder[i][0];
        encPoint[i] = (rawBorder[i][0] + 128 - rawBorder[i][1] - 1) / 2.0;
        if (rawBorder[i][0] < encPoint[i]) {
          encPoint[i] += rawBorder[i][1];
        }
        else {
          encPoint[i] -= rawBorder[i][0];
        }
        if (encPoint[i] > 0) {
          if ((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])) {
            encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
          }
          else if ((rawPos[i] < encPoint[i]) && (rawPos[i] >= rawBorder[i][1])) {
            encPos[i] = (int)1.00;
          }
          else {
            encPos[i] = (int)0.00;
          }
        }
        else {
          if ((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])) {
            encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
          }
          else if ((rawPos[i] > -encPoint[i]) && (rawPos[i] <= rawBorder[i][0])) {
            encPos[i] = (int)0.00;
          }
          else {
            encPos[i] = (int)1.00;
          }
        }
      }
      else {
        rawNorm[i] = 128 - rawBorder[i][0] + rawBorder[i][1] + 1;
        encPoint[i] = (rawBorder[i][0] - rawBorder[i][1] - 1) / 2.0;
        encPoint[i] += rawBorder[i][1];
        if (rawPos[i] >= rawBorder[i][0]) {
          encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
        }
        else if (rawPos[i] <= rawBorder[i][1]) {
          encPos[i] = (rawPos[i] + 128 - rawBorder[i][0]) / rawNorm[i];
        }
        else if (rawPos[i] < encPoint[i]) {
          encPos[i] = (int)1.00;
        }
        else {
          encPos[i] = (int)0.00;
        }
      }

      if (encType[i] == 0) {
        encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
      }

      if (encType[i] == 3) {
        encPos[i] = round((1 - encPos[i]) * (encBorder[i][1] - encBorder[i][0]));
        if (encPos[i] == encBorder[i][1]) {
          encPos[i] = encBorder[i][0];
        }
      }
    }
    oldEncPos[i] = encPos[i];
    Serial.print("e");
    Serial.print("#");
    Serial.print(i);
    Serial.print("#");
    Serial.println((int)encPos[i]);
    
    n++;
  }
#endif

  ////                                                                            ////
  //        НАСТРОЙКИ СВЕТОДИОДОВ                                                   //
  ////                                                                            ////

  for (int i = 0; i < DIODNUM; i++) {
    pinMode(diodIn[i], OUTPUT); // Настройка пина на выход
    digitalWrite(diodIn[i], LOW); // Выключение светодиодов
  }

} // КОНЕЦ НАСТРОЕК

void loop() {

  ////////////////////////////////////////////////////////////////////////////////////
  ////////                                                                    ////////
  ////                                                                            ////
  //        РАБОТА                                                                  //
  ////                                                                            ////
  ////////                                                                    ////////
  ////////////////////////////////////////////////////////////////////////////////////
  if (checkElem == false) // Проверка окончания всех настроек
    /*if (n == ELEMNUM)*/{
    //Serial.print("SETUP DONE");
    Serial.println("stop");
    checkElem = true;
  }
  ////                                                                            ////
  //        РАБОТА ТРЕХПОЗИЦИОННЫХ ТУМБЛЕРОВ                                        //
  ////                                                                            ////

  for (int i = 0; i < TOGGNUM; i++) { // Опрос тумблеров
    if (digitalRead(toggIn1[i]) == LOW && toggLog1[i] == false) {
      delay(50);
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("1");
      toggLog1[i] = true;
    }
    else if (digitalRead(toggIn2[i]) == LOW && toggLog2[i] == false) {
      delay(50);
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("2");
      toggLog2[i] = true;
    }
    else if ((digitalRead(toggIn1[i]) == HIGH && toggLog1[i] == true) || (digitalRead(toggIn2[i]) == HIGH && toggLog2[i] == true)) {
      delay(50);
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("0");
      toggLog1[i] = false;
      toggLog2[i] = false;
    }
  }

  ////                                                                            ////
  //        РАБОТА ПРЕДОХРАНИТЕЛЕЙ                                                  //
  ////                                                                            ////

  for (int i = 0; i < FUSENUM; i++) { // Опрос предохранителей
    if (digitalRead(fuseIn[i]) == LOW && fuseLog[i] == false) {
      delay(50);
      Serial.print("f");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");  
      Serial.println("1");
      fuseLog[i] = true;
    }
    else if (digitalRead(fuseIn[i]) == HIGH && fuseLog[i] == true) {
      delay(50);
      Serial.print("f");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");  
      Serial.println("0");
      fuseLog[i] = false;
    }
  }

  ////                                                                            ////
  //        РАБОТА РАЗЪЕМОВ                                                         //
  ////                                                                            ////

  for (int i = 0; i < CONNNUM; i++) { // Опрос разъемов
    if ((digitalRead(connPin[i]) == HIGH) && (connPos[i] == true)) {
      t = millis();
      if ((t - connTime[i]) > connDelay[i]) {
        Serial.print("c");
        Serial.print("#");
        Serial.print(i);
        Serial.print("#");
        Serial.println("0");
        connTime[i] = t;
        connPos[i] = false;
      }
    }
    else if ((digitalRead(connPin[i]) == LOW) && (connPos[i] == false)) {
      t = millis();
      if ((t - connTime[i]) > connDelay[i]) {
        Serial.print("c");
        Serial.print("#");
        Serial.print(i);
        Serial.print("#");
        Serial.println("1");
        connTime[i] = t;
        connPos[i] = true;
      }
    }
  }

  ////                                                                            ////
  //        РАБОТА ПОТЕНЦИОМЕТРОВ                                                   //
  ////                                                                            ////

  for (i = 0; i < POTNUM; i++) { // Опрос потенциометров
    potPos[i] = analogRead(potPin[i]);
    if (abs(potPos[i] - oldPotPos[i]) > POTERROR) {
      oldPotPos[i] = potPos[i];
      truePotPos[i] = potPos[i] / POTERROR * POTERROR;
      if (truePotPos[i] > 1000) {
        truePotPos[i] = 1000;
      }
      if (oldTruePotPos[i] != truePotPos[i]) {
        oldTruePotPos[i] = truePotPos[i];
        Serial.print("p");
        Serial.print("#");
        Serial.print(i);
        Serial.print("#");
        Serial.println(truePotPos[i]);
        
      }
    }
  }

  //        РАБОТА КНОПОК                                                           //
  ////                                                                            ////
  for (int i = 0; i < BUTTNUM; i++) { // Опрос кнопок
    if (buttRev[i] == false) {
      if ((digitalRead(buttPin[i]) == HIGH) && (buttPos[i] == true)) {
        t = millis();
        if ((t - buttTime[i]) > BUTTDELAY) {
          Serial.print("b");
          Serial.print("#");
          Serial.print(i);
          Serial.print("#");
          Serial.println("0");
          buttTime[i] = t;
          buttPos[i] = false;
        }
      }
      else if ((digitalRead(buttPin[i]) == LOW) && (buttPos[i] == false)) {
        t = millis();
        if ((t - buttTime[i]) > BUTTDELAY) {
          Serial.print("b");
          Serial.print("#");
          Serial.print(i);
          Serial.print("#");
          Serial.println("1");
          buttTime[i] = t;
          buttPos[i] = true;
        }
      }
    }
    else {
      if ((digitalRead(buttPin[i]) == HIGH) && (buttPos[i] == false)) {
        t = millis();
        if ((t - buttTime[i]) > BUTTDELAY) {
          Serial.print("b");
          Serial.print("#");
          Serial.print(i);
          Serial.print("#");
          Serial.println("1");
          buttTime[i] = t;
          buttPos[i] = true;
        }
      }
      else if ((digitalRead(buttPin[i]) == LOW) && (buttPos[i] == true)) {
        t = millis();
        if ((t - buttTime[i]) > BUTTDELAY) {
          Serial.print("b");
          Serial.print("#");
          Serial.print(i);
          Serial.print("#");
          Serial.println("0");
          buttTime[i] = t;
          buttPos[i] = false;
        }
      }
    }
  }

  ////                                                                            ////
  //        РАБОТА ЭНКОДЕРОВ                                                        //
  ////                                                                            ////

  // ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
  rawPos[0] = enc0.rawPos(); // Опрос энкодера
  rawPos[1] = enc1.rawPos();
  rawPos[2] = enc2.rawPos();
  rawPos[3] = enc3.rawPos();
  rawPos[4] = enc4.rawPos();
  rawPos[5] = enc5.rawPos();
  rawPos[6] = enc6.rawPos();
  rawPos[7] = enc7.rawPos();
  rawPos[8] = enc8.rawPos();
  rawPos[9] = enc9.rawPos();
  rawPos[10] = enc10.rawPos();
  rawPos[11] = enc11.rawPos();
  rawPos[12] = enc12.rawPos();
  rawPos[13] = enc13.rawPos();

#ifdef ENCSETUP
  for (i = 0; i < ENCNUM; i++) {
    if (rawPos[i] != oldRawPos[i]) { // Вывод текущего положения энкодера при наличии изменений
      oldRawPos[i] = rawPos[i];
      Serial.print("e");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println(rawPos[i]);
    }
  }
#endif

#ifndef ENCSETUP
  for (i = 0; i < ENCNUM; i++) { // Вывод в порт ПК текущего состояния энкодера
    if (rawPos[i] != oldRawPos[i]) {
      oldRawPos[i] = rawPos[i];
      if (rawPos[i] == 255) {
#ifdef DEBUG
        Serial.print("e");
        Serial.print("#");
        Serial.print(i);
        Serial.print("#");
        Serial.println("ERROR");
#endif
      }
      else {
        if (rawBorder[i][0] < rawBorder[i][1]) {
          if (encPoint[i] > 0) {
            if ((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])) {
              encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
            }
            else if ((rawPos[i] < encPoint[i]) && (rawPos[i] >= rawBorder[i][1])) {
              encPos[i] = 1.00;
            }
            else {
              encPos[i] = 0.00;
            }
          }
          else {
            if ((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])) {
              encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
            }
            else if ((rawPos[i] > -encPoint[i]) && (rawPos[i] <= rawBorder[i][0])) {
              encPos[i] = 0.00;
            }
            else {
              encPos[i] = 1.00;
            }
          }
        }
        else {
          if (rawPos[i] >= rawBorder[i][0]) {
            encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
          }
          else if (rawPos[i] <= rawBorder[i][1]) {
            encPos[i] = (rawPos[i] + 128 - rawBorder[i][0]) / rawNorm[i];
          }
          else if (rawPos[i] < encPoint[i]) {
            encPos[i] = 1.00;
          }
          else {
            encPos[i] = 0.00;
          }
        }

        if (encType[i] == 0) {
          encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
        }

        if (encType[i] == 3) {
          encPos[i] = round((1 - encPos[i]) * (encBorder[i][1] - encBorder[i][0]));
          if (encPos[i] == encBorder[i][1]) {
            encPos[i] = encBorder[i][0];
          }
        }

        if (encPos[i] != oldEncPos[i]) {
          oldEncPos[i] = encPos[i];
          Serial.print("e");
          Serial.print("#");
          Serial.print(i);
          Serial.print("#");
          Serial.println(encPos[i]);
          
        }
      }
    }
  }
#endif

  ////////////////////////////////////////////////////////////////////////////////////
  ////////                                                                    ////////
  ////                                                                            ////
  //        СВЯЗЬ С ПК                                                              //
  ////                                                                            ////
  ////////                                                                    ////////
  ////////////////////////////////////////////////////////////////////////////////////

  if (Serial.available() > 0) { // Проверка, что есть данные от ПК
    str = Serial.readStringUntil('\n');
#ifdef DEBUG
    //  Serial.print("USER: ");
    //  Serial.println(str);
#endif

    ////                                                                            ////
    //        СВЯЗЬ С ПК ДЛЯ ТРЕХПОЗИЦИОННЫХ ТУМБЛЕРОВ                                //
    ////                                                                            ////

    if (str.substring(0, 4).equals("togg")) { // Принудительный опрос тумблеров
      i = str.substring(4, 7).toInt();
      if (digitalRead(toggIn1[i]) == HIGH && digitalRead(toggIn2[i]) == HIGH) {
        /*    Serial.print("t");
            Serial.print(i);
            Serial.println(" off");  */
      }
      else if (digitalRead(toggIn1[i]) == LOW) {
        /*       Serial.print("t");
               Serial.print(i);
               Serial.println(" H");  */
      }
      else if (digitalRead(toggIn2[i]) == LOW) {
        /*   Serial.print("t");
           Serial.print(i);
           Serial.println(" L"); */
      }
    }

    ////                                                                            ////
    //        СВЯЗЬ С ПК ДЛЯ ПРЕДОХРАНИТЕЛЕЙ                                          //
    ////                                                                            ////

    else if (str.substring(0, 4).equals("fuse")) { // Принудительный опрос предохранителя
      i = str.substring(4, 5).toInt();
      if (digitalRead(fuseIn[i]) == HIGH) {
        /* Serial.print("f");
          Serial.print(i);
          Serial.println(" off"); */
      }
      else if (digitalRead(fuseIn[i]) == LOW) {
        /* Serial.print("f");
          Serial.print(i);
          Serial.println(" on");*/
      }
    }

    ////                                                                            ////
    //        СВЯЗЬ С ПК ДЛЯ РАЗЪЕМОВ                                                 //
    ////                                                                            ////

    if (str.substring(0, 4).equals("conn")) { // Принудительный опрос разъема
      i = str.substring(4, 6).toInt();
      if (i < CONNNUM) {
        if (connPos[i] == false) {
          /*Serial.print("c");
            Serial.print(i);
            Serial.print(" off");
            Serial.println("z");  */
        }
        else if (connPos[i] == true) {
          /* Serial.print("c");
            Serial.print(i);
            Serial.print(" on");
            Serial.println("z");*/
        }
      }
    }

    ////                                                                            ////
    //        СВЯЗЬ С ПК ДЛЯ ПОТЕНЦИОМЕТРОВ                                           //
    ////                                                                            ////

    if (str.substring(0, 3).equals("pot")) { // Принудительный опрос потенциометра
      i = str.substring(3, 5).toInt();
      if (i < POTNUM) {
        /*   Serial.print("p");
           Serial.print(i);
           Serial.print(" ");
           Serial.print(truePotPos[i]);
           Serial.println("z");*/
      }
    }

    ////                                                                            ////
    //        СВЯЗЬ С ПК ДЛЯ СВЕТОДИОДОВ                                              //
    ////                                                                            ////

    /*else if (str.equals("on")) { // Включить все светодиоды
      for (i = 0; i < DIODNUM; i++) {
        digitalWrite(diodIn[i], HIGH);
        diodLog[i] = true;
      }
      // Serial.println("on");
      }

      else if (str.equals("off")) { // Выключить все светодиоды
      for (i = 0; i < DIODNUM; i++) {
        digitalWrite(diodIn[i], LOW);
        diodLog[i] = false;
      }
      // Serial.println("off");
      }*/

    else if (str.substring(0, 3).equals("on0")) { // Включить светодиод
      //i = str.substring(2, 4).toInt();
      digitalWrite(diodIn[i], HIGH);
      diodLog[i] = true;
      /* Serial.print("l");
        Serial.print(i);
        Serial.println(" on");*/
    }

    else if (str.substring(0, 4).equals("off0")) { // Выключить светодиод
      // i = str.substring(3, 5).toInt();
      digitalWrite(diodIn[i], LOW);
      diodLog[i] = false;
      /* Serial.print("l");
        Serial.print(i);
        Serial.println(" off");*/
    }

    else if (str.substring(0, 4).equals("lamp")) { // Принудительный опрос светодиода
      i = str.substring(4, 6).toInt();
      /* Serial.print("l");
        Serial.print(i);*/
      if (diodLog[i] == false) {
        //Serial.println(" off");
      }
      else {
        // Serial.println(" on");
      }
    }

    //        СВЯЗЬ С ПК ДЛЯ КНОПОК                                                   //
    ////                                                                            ////
    if (str.substring(0, 4).equals("butt")) { // Принудительный опрос кнопки
      i = str.substring(4, 6).toInt();
      if (i < BUTTNUM) {
        if (buttPos[i] == false) {
          /* Serial.print("b");
            Serial.print(i);
            Serial.print(" off");
            Serial.println("z");  */
        }
        else if (buttPos[i] == true) {
          /* Serial.print("b");
            Serial.print(i);
            Serial.print(" on");
            Serial.println("z");*/
        }
      }
    }

    ////                                                                            ////
    //        СВЯЗЬ С ПК ДЛЯ ЭНКОДЕРОВ                                                //
    ////                                                                            ////

    else if (str.substring(0, 3).equals("enc")) { // Запрос состояния энкодера от ПК и вывод в порт ПК
      i = str.substring(3, 4).toInt();
      if (i < ENCNUM) {
        /* Serial.print("e");
          Serial.print(i);
          Serial.print(" ");*/
#ifdef ENCSETUP
        // Serial.println(rawPos[i]);
#endif
#ifndef ENCSETUP
        /* Serial.print(encPos[i]);
          Serial.println("z");*/
#endif
      }
    }

  } //КОНЕЦ СВЯЗИ

}
