////////////////////////////////////////////////////////////////////////////////////
////////                                                                    ////////
////                                                                            ////
//        БИБЛИОТЕКИ                                                              //
////                                                                            ////
////////                                                                    ////////
////////////////////////////////////////////////////////////////////////////////////

//        БИБЛИОТЕКИ ЭНКОДЕРОВ                                                    //
////                                                                            ////

#include <ACE128.h>
#include <ACE128map87654321.h> // Карта пинов 87654321

////////////////////////////////////////////////////////////////////////////////////
////////                                                                    ////////
////                
////
//        ПЕРЕМЕННЫЕ                                                              //
////                                                                            ////
////////                                                                    ////////
////////////////////////////////////////////////////////////////////////////////////

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО СВЕТОДИОДОВ!
#define DIODNUM 2

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО СВЕТОДИОДОВ!
const byte diodIn[DIODNUM] = {2,3}; // Пины светодиодов
bool diodLog[DIODNUM] = {false, false}; // Переменная для определения изменений в положении светодиодов

//////////////////////////////////

///////////////////////Кнопки и тумблеры 2////////////////////////////
////2 позиции////
// Задержка
#define BUTTDELAY 50
// Количество кнопок
#define BUTTNUM 5
// Пины кнопок
const byte buttPin[BUTTNUM] = {14, 15, 16, 17, 18};
// Положение кнопки
boolean buttPos[BUTTNUM] = {false,false,false,false,false};
// Реверс кнопки
boolean buttRev[BUTTNUM] = {false,false,false,false,false};
// Момент времени изменения положения кнопки
unsigned long buttTime[BUTTNUM] = {0,0,0,0,0};

////                                                                            ////
//        ПЕРЕМЕННЫЕ РАЗЪЕМОВ 2    - new                                            //
////                                                                            ////

//#define razSetup

#define razERROR 20 // Шум в значении потенциометра

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО РАЗЪЕМОВ 2!
#define razNUM 11

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО РАЗЪЕМОВ 2!
const byte razPin[razNUM] = {A7,A8,A9,A10,A11,A6,A5,A4,A3,A2,A1}; // Пины РАЗЪЕМОВ 2 {0, 1, 2}

int razPos[razNUM] = {0,0,0,0,0,0,0,0,0,0,0}; // Положение потенциометра

int oldrazPos[razNUM] = {0,0,0,0,0,0,0,0,0,0,0}; // Предыдущее положение потенциометра
int razType[razNUM] = {0,0,0,0,0,0,0,0,0,0,0}; // Тип потенциометра
int razBorder[razNUM][2] = {{0, 1000},{0, 1000},{0, 1000},{0, 1000},{0, 1000},
                {0, 1000},{0, 1000},{0, 1000},{0, 1000},{0, 1000},{0, 1000}};

int razAnswer[razNUM] = {320,280,240,200,160,360,380,400,420,440,480};

#define razERRORAnswer 15

// Границы значений потенциометра

double truerazPos[razNUM] = {0,0,0,0,0,0,0,0,0,0,0}; // Положение потенциометра по шкале
double oldTruerazPos[razNUM] = {0,0,0,0,0,0,0,0,0,0,0}; // Старое положение потенциометра по шкале

int truerazAnswer[razNUM] = {0,0,0,0,0,0,0,0,0,0,0}; // Положение потенциометра по шкале
int oldTruerazAnswer[razNUM] = {2,2,2,2,2,2,2,2,2,2,2}; // Старое положение потенциометра по шкале

unsigned long razTime[razNUM] = {0,0,0,0,0,0,0,0,0,0,0}; // Момент времени изменения положения кнопки

#define razDELAY 1500 // Время между двумя изменениями
#define razDELAYsetup 20 // Время между двумя изменениями

////                                                                            ////
//        ПЕРЕМЕННЫЕ ПОТЕНЦИОМЕТРОВ                                               //
////                                                                            ////

#define POTERROR 20 // Шум в значении потенциометра

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ПОТЕНЦИОМЕТРОВ!
#define POTNUM 1

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ПОТЕНЦИОМЕТРОВ!
const byte potPin[POTNUM] = {A0}; // Пины потенциометров

int potPos[POTNUM] = {0}; // Положение потенциометра
int oldPotPos[POTNUM] = {0}; // Предыдущее положение потенциометра
int potType[POTNUM] = {0}; // Тип потенциометра
int potBorder[POTNUM][2] = {{0, 1000}};
// Границы значений потенциометра

double truePotPos[POTNUM] = {0}; // Положение потенциометра по шкале
double oldTruePotPos[POTNUM] = {0}; // Старое положение потенциометра по шкале

//////////////////////////////////

//#define ENCSETUP // Раскомментировать для настройки
//#define ENCODERSETUP

#define ENCNUM 5 // Количество энкодеров

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
const byte encoderAddress[ENCNUM]= {32,33,34,35,36}; // Адреса энкодеров

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
ACE128 enc0((uint8_t)encoderAddress[0], (uint8_t*)encoderMap_87654321); // Адрес и карта энкодера
ACE128 enc1((uint8_t)encoderAddress[1], (uint8_t*)encoderMap_87654321);
ACE128 enc2((uint8_t)encoderAddress[2], (uint8_t*)encoderMap_87654321);
ACE128 enc3((uint8_t)encoderAddress[3], (uint8_t*)encoderMap_87654321);
ACE128 enc4((uint8_t)encoderAddress[4], (uint8_t*)encoderMap_87654321);
ACE128 enc5((uint8_t)encoderAddress[5], (uint8_t*)encoderMap_87654321);

uint8_t rawPos[ENCNUM] = {0,0,0,0,0}; // Текущее положение энкодера
uint8_t oldRawPos[ENCNUM] = {127,127,127,127,127}; // Предыдущее положение энкодера

#ifndef ENCSETUP
  int encType[ENCNUM] = {0,0,0,0,0}; // Тип энкодера !!!  0 - приведение к границам, 1 - границы и круговой, 4 - круговой (0.00 - 1.00)
  int rawBorder[ENCNUM][2] = {{97, 25},{99, 31},{29, 89},{87, 19},{76, 8}};
  // Границы положений энкодера
  int encBorder[ENCNUM][2] = {{0, 6},{0, 9},{0, 9},{0, 9},{0, 9}};
  // Границы положений энкодера по шкале
  
  double encPoint[ENCNUM] = {0,0,0,0,0}; // Средняя точка
  double encPos[ENCNUM] = {0,0,0,0,0}; // Положение энкодера по шкале
  double oldEncPos[ENCNUM] = {0,0,0,0,0}; // Предыдущее положение энкодера по шкале
  double rawNorm[ENCNUM] = {0,0,0,0,0}; // Норма
#endif
////////////////////////////////////////
#define ELEMNUM 24

String str = "";
int i;
int n = 0;
unsigned long t = 0;
boolean checkElem = false;
long j2;
unsigned long traz = 0;

void setup() {

  Serial.begin(115200); // Инициализация порта для работы с ПК

  #ifdef DEBUG
  //Serial.println("DEBUG DEFINED");
  #endif

  Serial.println("R-333");
  Serial.println("complite");

////                                                                            ////
//        НАСТРОЙКИ СВЕТОДИОДОВ                                                   //
////                                                                            ////
 
 for(int i = 0; i < DIODNUM; i++){
    pinMode(diodIn[i], OUTPUT); // Настройка пина на выход
    digitalWrite(diodIn[i], LOW); // Выключение светодиодов
  }

//        НАСТРОЙКИ КНОПОК                                                       //
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

//////////////НАСТРОЙКИ РАЗЪЕМОВ 2///////////////////

  for (i = 0; i < razNUM; i++) { // Опрос РАЗЪЕМОВ 2
    razPos[i] = analogRead(razPin[i]);
    oldrazPos[i] = razPos[i];
    truerazPos[i] = razPos[i];
    if (truerazPos[i] > razBorder[i][1]) {
      truerazPos[i] = razBorder[i][1];
    }
    else if (truerazPos[i] < razBorder[i][0]) {
      truerazPos[i] = razBorder[i][0];
    }
    truerazPos[i] = (truerazPos[i] - razBorder[i][0]) / (razBorder[i][1] - razBorder[i][0]) * 1000;
    truerazPos[i] = (int)round(truerazPos[i]) / razERROR * razERROR;

    oldTruerazPos[i] = truerazPos[i];


#ifndef razSetup
    if (razAnswer[i] >= truerazPos[i] - razERRORAnswer && razAnswer[i] <= truerazPos[i] + razERRORAnswer)
    {
      //if (razAnswer[i] == truerazPos[i]) {
      Serial.print("c");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");


      Serial.println("1");

      truerazAnswer[i] = 1;
    } else {
      Serial.print("c");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");


      Serial.println("0");

    }
    oldTruerazAnswer[i] = truerazAnswer[i];
#else

    Serial.print("c");
    Serial.print(i);
    Serial.print(" ");
    Serial.println(truerazPos[i]);


#endif


  }

////                                                                            ////
//        НАСТРОЙКИ ПОТЕНЦИОМЕТРОВ                                                //
////                                                                            ////

  for (i = 0; i < POTNUM; i++){ // Опрос потенциометров
    potPos[i] = analogRead(potPin[i]);
    oldPotPos[i] = potPos[i];
    truePotPos[i] = potPos[i];
    if(truePotPos[i] > potBorder[i][1]){
      truePotPos[i] = potBorder[i][1];
    }
    else if(truePotPos[i] < potBorder[i][0]){
      truePotPos[i] = potBorder[i][0];
    }
    truePotPos[i] = (truePotPos[i] - potBorder[i][0]) / (potBorder[i][1] - potBorder[i][0]) * 100;
    truePotPos[i] = (int)round(truePotPos[i]) / POTERROR * POTERROR;
    
    oldTruePotPos[i] = truePotPos[i];
    Serial.print("p");
    Serial.print("#");
    Serial.print(i);
    Serial.print("#");
    Serial.println((int)truePotPos[i]);
    
    n++;
  }
////////////////////////////////////////////////////
#ifdef ENCODERSETUP
    Serial.println("ENCODERSETUP DEFINED");
  #endif
  
// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
  enc0.begin(); // Инициализация работы энкодера
 enc1.begin(); // Инициализация работы энкодера
 enc2.begin(); // Инициализация работы энкодера
 enc3.begin(); // Инициализация работы энкодера
 enc4.begin(); // Инициализация работы энкодера
// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
  rawPos[0] = enc0.rawPos(); // Опрос энкодера
  rawPos[1] = enc1.rawPos(); // Опрос энкодера
  rawPos[2] = enc2.rawPos(); // Опрос энкодера
  rawPos[3] = enc3.rawPos(); // Опрос энкодера
  rawPos[4] = enc4.rawPos(); // Опрос энкодера
  #ifdef ENCSETUP
    for(i = 0; i < ENCNUM; i++){ // Вывод текущего положения энкодера
      oldRawPos[i] = rawPos[i];
      Serial.print("e");
      Serial.print(i);
      Serial.print(" ");
      Serial.println(rawPos[i]);
    }
  
  #endif

    #ifdef ENCODERSETUP
    Serial.println("ENCODERSETUP DEFINED 2");
  #endif

  #ifndef ENCSETUP
    for(i = 0; i < ENCNUM; i++){ // Вывод в порт ПК текущего состояния энкодера
      oldRawPos[i] = rawPos[i];
      if(rawPos[i] == 255){
        #ifdef DEBUG
          Serial.print("e");
          Serial.print(i);
          Serial.print(" ");
          Serial.println("ERROR");
        #endif
        encPos[i] = encBorder[i][0];
      }
      else{
        if (rawBorder[i][0] < rawBorder[i][1]){
          rawNorm[i] = rawBorder[i][1] - rawBorder[i][0];
          encPoint[i] = (rawBorder[i][0] + 128 - rawBorder[i][1] - 1) / 2.0;
          if(rawBorder[i][0] < encPoint[i]){
            encPoint[i] += rawBorder[i][1];
          }
          else{
            encPoint[i] -= rawBorder[i][0];
          }
          if(encPoint[i] > 0){
            if((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])){
              encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
            }
            else if((rawPos[i] < encPoint[i]) && (rawPos[i] >= rawBorder[i][1])){
              encPos[i] = 1.00;
            }
            else{
              encPos[i] = 0.00;
            }
          }
          else{
            if((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])){
              encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
            }
            else if((rawPos[i] > -encPoint[i]) && (rawPos[i] <= rawBorder[i][0])){
              encPos[i] = 0.00;
            }
            else{
              encPos[i] = 1.00;
            }
          }
        }
        else{
          rawNorm[i] = 128 - rawBorder[i][0] + rawBorder[i][1] + 1;
          encPoint[i] = (rawBorder[i][0] - rawBorder[i][1] - 1) / 2.0;
          encPoint[i] += rawBorder[i][1];
          if(rawPos[i] >= rawBorder[i][0]){
            encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
          }
          else if(rawPos[i] <= rawBorder[i][1]){
            encPos[i] = (rawPos[i] + 128 - rawBorder[i][0]) / rawNorm[i];
          }
          else if(rawPos[i] < encPoint[i]){
            encPos[i] = 1.00;
          }
          else{
            encPos[i] = 0.00;
          }
        }
  
        if(encType[i] == 0){
          encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
        }
  
        if(encType[i] == 1){
          encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
          if(encPos[i] == encBorder[i][1]){
            encPos[i] = encBorder[i][0];
          }
        }

        if(encType[i] == 2){
          encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0])) * 5.0;
          if(encPos[i] == encBorder[i][1]){
            encPos[i] = encBorder[i][0];
          }
        }

        if(encType[i] == 4){
          encPos[i] = round(encPos[i] * 100)  / 100.0;
        }
      }
      oldEncPos[i] = encPos[i];
      Serial.print("e");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println(encPos[i]);
      n++;
    }

  #endif


   #ifdef ENCODERSETUP
    Serial.println("ENCODERSETUP DEFINED 3");
  #endif

Serial.println("stop");
}

void loop() {

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
        Serial.println("1");
          buttTime[i] = t;
          buttPos[i] = false;
        }
      }
    }
  }

//////////////РАБОТА РАЗЪЕМОВ 2///////////////////
  for (i = 0; i < razNUM; i++) { // Опрос РАЗЪЕМОВ 2

    traz = millis();


    if ((traz - razTime[i]) > razDELAY) {



      razPos[i] = analogRead(razPin[i]);
      if (abs(razPos[i] - oldrazPos[i]) > razERROR) {
        oldrazPos[i] = razPos[i];
        truerazPos[i] = razPos[i];
        if (truerazPos[i] > razBorder[i][1]) {
          truerazPos[i] = razBorder[i][1];
        }
        else if (truerazPos[i] < razBorder[i][0]) {
          truerazPos[i] = razBorder[i][0];
        }
        truerazPos[i] = (truerazPos[i] - razBorder[i][0]) / (razBorder[i][1] - razBorder[i][0]) * 1000;

        truerazPos[i] = (int)round(truerazPos[i]) / razERROR * razERROR;

        if (razType[i] == 0) {


          if (oldTruerazPos[i] != truerazPos[i]) {
            oldTruerazPos[i] = truerazPos[i];

            //if (razAnswer[i] == truerazPos[i]) {



#ifndef razSetup
            if (razAnswer[i] >= truerazPos[i] - razERRORAnswer && razAnswer[i] <= truerazPos[i] + razERRORAnswer)
            {

              truerazAnswer[i] = 1;
            } else {
              truerazAnswer[i] = 0;
            }
            if (truerazAnswer[i] != oldTruerazAnswer[i]) {
              Serial.print("c");
              Serial.print("#");
              Serial.print(i);
              Serial.print("#");


              if (truerazAnswer[i] == 1) {
                Serial.println("1");
              } else {
                Serial.println("0");
              }


              oldTruerazAnswer[i] = truerazAnswer[i];
              /*
                Serial.print("p");
                Serial.print(i);
                Serial.print(" ");
                Serial.print(truerazPos[i]);
                Serial.println("z");
              */
            }

#else


            Serial.print("c");
            Serial.print(i);
            Serial.print(" ");
            Serial.println(truerazPos[i]);



#endif



          }
        }
      }
      razTime[i] = traz;
    }

  }

////                                                                            ////
//        РАБОТА ПОТЕНЦИОМЕТРОВ                                                   //
////                                                                            ////

  for (i = 0; i < POTNUM; i++) { // Опрос потенциометров
    potPos[i] = analogRead(potPin[i]);
    if (abs(potPos[i] - oldPotPos[i]) > POTERROR) {
      oldPotPos[i] = potPos[i];
      truePotPos[i] = potPos[i];
      if(truePotPos[i] > potBorder[i][1]){
        truePotPos[i] = potBorder[i][1];
      }
      else if(truePotPos[i] < potBorder[i][0]){
        truePotPos[i] = potBorder[i][0];
      }
      truePotPos[i] = (truePotPos[i] - potBorder[i][0]) / (potBorder[i][1] - potBorder[i][0]) * 100;
      truePotPos[i] = (int)round(truePotPos[i]) / POTERROR * POTERROR;
      
      if(potType[i] == 0){
        if(oldTruePotPos[i] != truePotPos[i]){
          oldTruePotPos[i] = truePotPos[i];
          Serial.print("p");
          Serial.print("#");
          Serial.print(i);
          Serial.print("#");
          Serial.println((int)truePotPos[i]);
        }
      }
    }
  }
  
////////////////////////////////////////////////////////
// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
  rawPos[0] = enc0.rawPos(); // Опрос энкодера
  rawPos[1] = enc1.rawPos(); // Опрос энкодера
  rawPos[2] = enc2.rawPos(); // Опрос энкодера
  rawPos[3] = enc3.rawPos(); // Опрос энкодера
  rawPos[4] = enc4.rawPos(); // Опрос энкодера
    

  #ifdef ENCSETUP
    for(i = 0; i < ENCNUM; i++){
      if (rawPos[i] != oldRawPos[i]){ // Вывод текущего положения энкодера при наличии изменений
        oldRawPos[i] = rawPos[i];     
        Serial.print("e");
        Serial.print(i);
        Serial.print(" ");
        Serial.println(rawPos[i]);
      }
    }
  #endif

  #ifndef ENCSETUP
    for(i = 0; i < ENCNUM; i++){ // Вывод в порт ПК текущего состояния энкодера
      if (rawPos[i] != oldRawPos[i]){
        oldRawPos[i] = rawPos[i];
        if(rawPos[i] == 255){
          #ifdef DEBUG
            Serial.print("e");
            Serial.print(i);
            Serial.print(" ");
            Serial.println("ERROR");
          #endif
        }
        else{
          if (rawBorder[i][0] < rawBorder[i][1]){
            if(encPoint[i] > 0){
              if((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])){
                encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
              }
              else if((rawPos[i] < encPoint[i]) && (rawPos[i] >= rawBorder[i][1])){
                encPos[i] = 1.00;
              }
              else{
                encPos[i] = 0.00;
              }
            }
            else{
              if((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])){
                encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
              }
              else if((rawPos[i] > -encPoint[i]) && (rawPos[i] <= rawBorder[i][0])){
                encPos[i] = 0.00;
              }
              else{
                encPos[i] = 1.00;
              }
            }
          }
          else{
            if(rawPos[i] >= rawBorder[i][0]){
              encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
            }
            else if(rawPos[i] <= rawBorder[i][1]){
              encPos[i] = (rawPos[i] + 128 - rawBorder[i][0]) / rawNorm[i];
            }
            else if(rawPos[i] < encPoint[i]){
              encPos[i] = 1.00;
            }
            else{
              encPos[i] = 0.00;
            }
          }
    
          if(encType[i] == 0){
            encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
          }

          if(encType[i] == 1){
            encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
            if(encPos[i] == encBorder[i][1]){
              encPos[i] = encBorder[i][0];
            }
          }

          if(encType[i] == 2){
            encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0])) * 5.0;
            if(encPos[i] == encBorder[i][1]){
              encPos[i] = encBorder[i][0];
            }
          }

          if(encType[i] == 4){
            encPos[i] = round(encPos[i] * 100)  / 100.0;
          }
          
          if(encPos[i] != oldEncPos[i]){
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

//////////////////////////////////////////////////////////////
if (Serial.available() > 0){ // Проверка, что есть данные от ПК
    str = Serial.readStringUntil('\n');
    //Serial.print("USER: ");
    //Serial.println(str);
    
////                                                                            ////
//        СВЯЗЬ С ПК ДЛЯ СВЕТОДИОДОВ                                              //
////                                                                            ////
   


     if (str.substring(0, 2).equals("on")){ // Включить светодиод
      i = str.substring(2, 4).toInt();
      digitalWrite(diodIn[i], HIGH);
      diodLog[i] = true;
   /*   Serial.print("l");
      Serial.print(i);
      Serial.println(" on");*/
    }

    else if (str.substring(0, 3).equals("off")){ // Выключить светодиод
      i = str.substring(3, 5).toInt();
      digitalWrite(diodIn[i], LOW);
      diodLog[i] = false;
  /*    Serial.print("l");
      Serial.print(i);
      Serial.println(" off");*/
    }

////                                                                            ////
//        СВЯЗЬ С ПК ДЛЯ ПОТЕНЦИОМЕТРОВ                                           //
////                                                                            ////

    if (str.substring(0, 3).equals("pot")) { // Принудительный опрос потенциометра
      i = str.substring(3, 5).toInt();
      if (i < POTNUM) {
        Serial.print("p");
        Serial.print(i);
        Serial.print(" ");
        Serial.print(truePotPos[i]);
        Serial.println(" z");
      }
    }






  }








  

}
