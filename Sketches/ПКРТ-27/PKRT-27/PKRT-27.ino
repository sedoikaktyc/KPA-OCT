
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

////                                                                            ////
//        БИБЛИОТЕКИ ШАГОВЫХ ДВИГАТЕЛЕЙ                                           //
////                                                                            ////

// БИБЛИОТЕКА НЕ ПОДДЕРЖИВАЕТ МАССИВЫ ДВИГАТЕЛЕЙ, ЕСЛИ ИЗМЕНИТСЯ КОЛИЧЕСТВО
// ДВИГАТЕЛЕЙ, ИЗМЕНЕНИЯ БУДУТ И В "НАСТРОКАХ", И В "РАБОТЕ", И В "СВЯЗИ С ПК"
#include <AccelStepper.h>

////////////////////////////////////////////////////////////////////////////////////
////////                                                                    ////////
////                                                                            ////
//        ПЕРЕМЕННЫЕ                                                              //
////                                                                            ////
////////                                                                    ////////
////////////////////////////////////////////////////////////////////////////////////

////                                                                            ////
//        ПЕРЕМЕННЫЕ ДВУХПОЗИЦИОННЫХ ТУМБЛЕРОВ                                    //
////                                                                            ////

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ТУМБЛЕРОВ!
#define TOGGNUM 6

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ТУМБЛЕРОВ!
const byte toggIn1[] = {32, 36, 40, 14, 16, 18}; // Пины тумблеров поз.1
bool toggLog1[] = {false, false, false, false, false, false, false, false}; // Переменная для определения изменений в положении тумблера

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ТУМБЛЕРОВ!
const byte toggIn2[] = {34, 38, 42, 15, 17, 19}; // Пины тумблеров поз.2
bool toggLog2[] = {false, false, false, false, false, false, false, false}; // Переменная для определения изменений в положении тумблера

////                                                                            ////
//        ПЕРЕМЕННЫЕ ПРЕДОХРАНИТЕЛЕЙ                                              //
////                                                                            ////

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ПРЕДОХРАНИТЕЛЕЙ!
#define FUSENUM 1

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ПРЕДОХРАНИТЕЛЕЙ!
const byte fuseIn[] = {2}; // Пины предохранителей
bool fuseLog[] = {false}; // Переменная для определения изменений в положении предохранителей

////                                                                            ////
//        ПЕРЕМЕННЫЕ РАЗЪЕМОВ                                                     //
////                                                                            ////

#define CONNDELAY0 50 // Время между двумя изменениями
#define CONNDELAY1 4000 // Время между двумя изменениями (для закручивающихся)

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО РАЗЪЕМОВ!
#define CONNNUM 1 // Количество разъемов

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО РАЗЪЕМОВ!
int connType[CONNNUM] = {1}; // Тип разъема
int connDelay[CONNNUM] = {0}; // Время между двумя изменениями

const byte connPin[CONNNUM] = {3}; // Пины разъемов

boolean connPos[CONNNUM] = {false}; // Положение разъемов

unsigned long connTime[CONNNUM] = {0}; // Момент времени изменения положения разъемов

////                                                                            ////
//        ПЕРЕМЕННЫЕ ПОТЕНЦИОМЕТРОВ                                               //
////                                                                            ////

#define POTERROR 15 // Шум в значении потенциометра

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ПОТЕНЦИОМЕТРОВ!
#define POTNUM 2
// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ПОТЕНЦИОМЕТРОВ!
const byte potPin[POTNUM] = {54, 55}; // Пины потенциометров

int potPos[POTNUM] = {0, 0}; // Положение потенциометра
int oldPotPos[POTNUM] = {0, 0}; // Предыдущее положение потенциометра
int truePotPos[POTNUM] = {0, 0}; // Округленное положение потенциометра
int oldTruePotPos[POTNUM] = {0, 0}; // Предыдущее округленное положение потенциометра


int i2, n2;

int im;



///////////////////////////////////////////////////NeoPixelBus befor setup ////////////////////////////////////////
#include <NeoPixelBus.h>

const uint16_t PixelCount = 20; // this example assumes 4 pixels, making it smaller will cause a failure
const uint8_t PixelPin = 13;  // make sure to set this to the correct pin, ignored for Esp8266

#define colorSaturation 128
NeoPixelBus<NeoGrbFeature, Neo800KbpsMethod> strip(PixelCount, PixelPin);
RgbColor red(colorSaturation, 0, 0);
RgbColor green(0, colorSaturation, 0);
RgbColor blue(0, 0, colorSaturation);
RgbColor white(colorSaturation);
RgbColor black(0);
HslColor hslRed(red);
HslColor hslGreen(green);
HslColor hslBlue(blue);
HslColor hslWhite(white);
HslColor hslBlack(black);
///////////////////////////////////////////////////NeoPixelBus befor setup ////////////////////////////////////////





///////////////////////МОТОРЫ//////////////////////////
#include <MCP3017AccelStepper.h>

long j2;

//#define STEPPER_SETUP // Раскомментировать для настройки
//#define STEPPER_DEBUG //Раскомментировать для поиска ошибок

#define STEPPER_NUM 2 // Количество шаговых двигателей

MCP3017AccelStepper stepper[STEPPER_NUM] = { // Определение двигателей
  MCP3017AccelStepper (AccelStepper::HALF4WIRE, 26, 28, 22, 24),
  MCP3017AccelStepper (AccelStepper::HALF4WIRE, 46, 48, 50, 52)
};


const byte stepperOptronPin[STEPPER_NUM] = {37, 44}; // Пины оптронов
String stepperSymbol = "s"; // Обозначение шаговых двигателей
String stepperSymbolB = "r";

#define STEPPER_ACCELERATION 200 // Ускорение //-
#define STEPPER_SPEED 100 // Скорость //-

#define STEPPER_ACCELERATION_yst 400 // Ускорение //-
#define STEPPER_SPEED_yst 200 // Скорость //-

boolean stepperBuzy[STEPPER_NUM] = {false, false}; // Статус работы

/////////////

boolean stepperZeroSettingLock[STEPPER_NUM] = {false, false}; // Блокировка движения в конце loop(){}
boolean stepperZeroSettingStepA[STEPPER_NUM] = {false, false}; // Логические шаги установки нуля
boolean stepperZeroSettingStepB[STEPPER_NUM] = {false, false};
boolean stepperZeroSettingStepC[STEPPER_NUM] = {false, false};
boolean stepperZeroSettingStepD[STEPPER_NUM] = {false, false};
boolean stepperZeroSettingStepE[STEPPER_NUM] = {false, false};

unsigned long stepperZeroSettingTimeC[STEPPER_NUM] = {0, 0}; // Измерение времени в логическом шаге
unsigned long stepperZeroSettingTimeD[STEPPER_NUM] = {0, 0};

#define STEPPER_ZERO_SETTING_SPEED_B 100 // Скорость, выставляемая в логическом шаге
#define STEPPER_ZERO_SETTING_DEAD_TIME_C 50 // Время ожидания перед шагом
#define STEPPER_ZERO_SETTING_DEAD_TIME_D 50

long stepperZeroPos[STEPPER_NUM] = {0, 0}; // Положение нуля

/////////////

#ifndef STEPPER_SETUP
boolean stepperZeroSettingStepF[STEPPER_NUM] = {false, false};
// Дополнительные логические шаги установки нуля
boolean stepperMoveStepA[STEPPER_NUM] = {false, false}; // Логические шаги сдвига
boolean stepperMoveStepB[STEPPER_NUM] = {false, false};

long stepperTrueZeroPos[STEPPER_NUM] = {8 , 22}; // Положение нуля шкалы
long stepperBorder[STEPPER_NUM][2] = {{0, 204}, {0, 145}}; // Границы шкалы
long stepperPos[STEPPER_NUM] = {0, 0};  // Текущее положение
#endif

//////////////

#ifdef STEPPER_DEBUG
long stepperDebugPos[STEPPER_NUM] = {0, 0};
#endif
//////////////////////////////////

////                                                                            ////
//        ПЕРЕМЕННЫЕ ЭНКОДЕРОВ                                                    //
////                                                                            ////

//#define ENCSETUP // Раскомментировать для настройки

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
#define ENCNUM 8 // Количество энкодеров

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
const byte encoderAddress[ENCNUM]= {32, 33, 36, 37, 34, 35}; // Адреса энкодеров

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
ACE128 enc0((uint8_t)encoderAddress[0], (uint8_t*)encoderMap_87654321); // Адрес и карта энкодера
ACE128 enc1((uint8_t)encoderAddress[1], (uint8_t*)encoderMap_87654321);
ACE128 enc2((uint8_t)encoderAddress[2], (uint8_t*)encoderMap_87654321);
ACE128 enc3((uint8_t)encoderAddress[3], (uint8_t*)encoderMap_87654321);
ACE128 enc4((uint8_t)encoderAddress[4], (uint8_t*)encoderMap_87654321);
ACE128 enc5((uint8_t)encoderAddress[5], (uint8_t*)encoderMap_87654321);

uint8_t rawPos[ENCNUM] = {0, 0, 0, 0, 0, 0}; // Текущее положение энкодера
uint8_t oldRawPos[ENCNUM] = {127, 127, 127, 127, 127, 127}; // Предыдущее положение энкодера

#ifndef ENCSETUP
  int encType[ENCNUM] = {0, 0, 0, 0, 0, 0}; // Тип энкодера
  int rawBorder[ENCNUM][2] = {{2, 63}, {21, 65}, {90, 84}, {56, 43}, {84, 124}, {72, 125}};
  // Границы положений энкодера
  int encBorder[ENCNUM][2] = {{0, 6}, {0, 4}, {0, 46}, {0, 18}, {0, 4}, {0, 5}};
  // Границы положений энкодера по шкале
  
  double encPoint[ENCNUM] = {0, 0, 0, 0, 0, 0}; //
  double encPos[ENCNUM] = {0, 0, 0, 0, 0, 0}; // Положение энкодера по шкале
  double oldEncPos[ENCNUM] = {0, 0, 0, 0, 0, 0}; // Предыдущее положение энкодера по шкале
  double rawNorm[ENCNUM] = {0, 0, 0, 0, 0, 0};
#endif

////                                                                            ////
//        ОБЩИЕ ПЕРЕМЕННЫЕ                                                        //
////                                                                            ////

//#define DEBUG // Раскомментировать для отладки

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭЛЕМЕНТОВ!
#define ELEMNUM 23

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
 Serial.println("PKRT-27");    
  Serial.println("complite");

////                                                                            ////
//        НАСТРОЙКИ ДВУХПОЗИЦИОННЫХ ТУМБЛЕРОВ                                     //
////                                                                            ////
 
 for(int i = 0; i < TOGGNUM; i++){
    pinMode(toggIn1[i], INPUT); // Настройка пина на вход
    digitalWrite(toggIn1[i], HIGH); // Подтяжка пина к питанию
    
    pinMode(toggIn2[i], INPUT);
    digitalWrite(toggIn2[i], HIGH);
  }

 for(int i = 0; i < TOGGNUM; i++){ // Опрос тумблеров
    if(digitalRead(toggIn1[i]) == HIGH && digitalRead(toggIn2[i]) == HIGH){
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
 
       Serial.println("0");        
    }
    else if(digitalRead(toggIn1[i]) == LOW){
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");

       Serial.println("1");      
      toggLog1[i] = true;      
    }
    else if(digitalRead(toggIn2[i]) == LOW){
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
 
 for(i = 0; i < CONNNUM; i++){
    pinMode(connPin[i], INPUT); // Настройка пина на вход
    digitalWrite(connPin[i], HIGH); // Подтяжка пина к питанию

    if(connType[i] == 0){
      connDelay[i] = CONNDELAY0;
    }
    else if(connType[i] == 1){
      connDelay[i] = CONNDELAY1;
    }
  }

 for(i = 0; i < CONNNUM; i++){ // Опрос разъемов
    if(digitalRead(connPin[i]) == HIGH){
      Serial.print("c");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");

      Serial.println("0");
    }
    else if(digitalRead(connPin[i]) == LOW){
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
    if(truePotPos[i] > 1000){
      truePotPos[i] = 1000;
    }
    oldTruePotPos[i] = truePotPos[i];
    Serial.print("p");
    Serial.print("#");
    Serial.print(i);
    Serial.print("#");

    Serial.print(truePotPos[i]);
    Serial.println(" ");
    n++;
  }

 

///////////////////////////////////////////////////NeoPixelBus setup ////////////////////////////////////////
    strip.Begin();
    strip.Show();
///////////////////////////////////////////////////NeoPixelBus setup ////////////////////////////////////////
   for(i = 0; i < PixelCount; i++){
          strip.SetPixelColor(i, hslBlack);
          strip.Show();
        }





  ///////////////////НАСТРОЙКИ МОТОРОВ////////////////////

#ifdef STEPPER_SETUP
  Serial.println("STEPPER SETUP DEFINED");


  
#endif




#ifdef STEPPER_DEBUG
  Serial.println("STEPPER DEBUG DEFINED");
#endif

#ifndef STEPPER_SETUP
  for (i = 0; i < STEPPER_NUM; i++) { // Включение установки нуля
    stepperZeroSettingStepA[i] = true;
  }
#endif

  for (i = 0; i < STEPPER_NUM; i++) { // Настройка двигателей
    stepper[i].setMaxSpeed(STEPPER_SPEED);
    stepper[i].setSpeed(STEPPER_SPEED);
    stepper[i].setAcceleration(STEPPER_ACCELERATION);
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

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
  rawPos[0] = enc0.rawPos(); // Опрос энкодера
  rawPos[1] = enc1.rawPos();
  rawPos[2] = enc2.rawPos();
  rawPos[3] = enc3.rawPos();
  rawPos[4] = enc4.rawPos();
  rawPos[5] = enc5.rawPos();

  #ifdef ENCSETUP
    for(i = 0; i < ENCNUM; i++){ // Вывод текущего положения энкодера
      oldRawPos[i] = rawPos[i];
      Serial.print("e");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");

      Serial.println(rawPos[i]);
    }
  #endif

  #ifndef ENCSETUP
    for(i = 0; i < ENCNUM; i++){ // Вывод в порт ПК текущего состояния энкодера
      oldRawPos[i] = rawPos[i];
      if(rawPos[i] == 255){
        #ifdef DEBUG
          Serial.print("e");
          Serial.print("#");
          Serial.print(i);
          Serial.print("#");

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
  
        if(encType[i] == 3){
          encPos[i] = round((1 - encPos[i]) * (encBorder[i][1] - encBorder[i][0]));
          if(encPos[i] == encBorder[i][1]){
            encPos[i] = encBorder[i][0];
          }
        }
      }
      oldEncPos[i] = encPos[i];
      Serial.print("e");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");

      Serial.print(int(encPos[i]));
      Serial.println(" ");
      n++;
    }
  #endif


} // КОНЕЦ НАСТРОЕК

void loop() {

////////////////////////////////////////////////////////////////////////////////////
////////                                                                    ////////
////                                                                            ////
//        РАБОТА                                                                  //
////                                                                            ////
////////                                                                    ////////
////////////////////////////////////////////////////////////////////////////////////

////                                                                            ////
//        РАБОТА ДВУХПОЗИЦИОННЫХ ТУМБЛЕРОВ                                        //
////                                                                            ////

 for(int i = 0; i < TOGGNUM; i++){ // Опрос тумблеров
    if(digitalRead(toggIn1[i]) == LOW && toggLog1[i] == false){
      delay(50);
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");

       Serial.println("1");      
      toggLog1[i] = true;     
    }
    else if(digitalRead(toggIn2[i]) == LOW && toggLog2[i] == false){
      delay(50);
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");

       Serial.println("2");      
      toggLog2[i] = true;      
    }
    else if((digitalRead(toggIn1[i]) == HIGH && toggLog1[i] == true) || (digitalRead(toggIn2[i]) == HIGH && toggLog2[i] == true)){
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

 for(int i = 0; i < CONNNUM; i++){ // Опрос разъемов
      if((digitalRead(connPin[i]) == HIGH) && (connPos[i] == true)){
        t = millis();
        if((t - connTime[i]) > connDelay[i]){
          Serial.print("c");
          Serial.print("#");
          Serial.print(i);
          Serial.print("#");

          Serial.println("0");
          connTime[i] = t;
          connPos[i] = false; 
        }
      }
      else if((digitalRead(connPin[i]) == LOW) && (connPos[i] == false)){
        t = millis();
        if((t - connTime[i]) > connDelay[i]){
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
      if(truePotPos[i] > 1000){
        truePotPos[i] = 1000;
      }
      if(oldTruePotPos[i] != truePotPos[i]){
        oldTruePotPos[i] = truePotPos[i];
        Serial.print("p");
        Serial.print("#");
        Serial.print(i);
        Serial.print("#");

        Serial.print(truePotPos[i]);
        Serial.println(" ");
      }
    }
  }

  /////////////////РАБОТА МОТОРОВ////////////////////
  for (i = 0; i < STEPPER_NUM; i++) {

    //        УСТАНОВКА НУЛЯ ШАГОВЫХ ДВИГАТЕЛЕЙ                                   //

    if (stepperZeroSettingStepA[i] == true) {
      if (digitalRead(stepperOptronPin[i]) == LOW) {

        stepper[i].setMaxSpeed(100);
        stepper[i].setSpeed(50);
        stepper[i].setAcceleration(8000);

        stepper[i].move(-800);
        stepperZeroSettingStepA[i] = false;
        stepperZeroSettingStepB[i] = true;
        stepperZeroSettingLock[i] = true;
#ifdef STEPPER_DEBUG
        Serial.println("a-b");
#endif
      }
      else {
        stepperZeroSettingStepA[i] = false;
        stepperZeroSettingStepC[i] = true;
#ifdef STEPPER_DEBUG
        Serial.println("a-c");
#endif
      }
      stepperBuzy[i] = true;
    }

    if (stepperZeroSettingStepB[i] == true) {
      if (digitalRead(stepperOptronPin[i]) == LOW) {
        stepper[i].run();
      }
      else {
        stepper[i].setMaxSpeed(STEPPER_ZERO_SETTING_SPEED_B);
        stepper[i].moveTo(stepper[i].currentPosition());
        stepperZeroSettingStepB[i] = false;
        stepperZeroSettingStepC[i] = true;
        stepperZeroSettingLock[i] = false;
        stepperZeroSettingTimeC[i] = millis();
#ifdef STEPPER_DEBUG
        Serial.println("b-c");
#endif
      }
    }

    if (stepperZeroSettingStepC[i] == true && stepper[i].distanceToGo() == 0
        && (millis() - stepperZeroSettingTimeC[i]) > STEPPER_ZERO_SETTING_DEAD_TIME_C) {
      stepper[i].move(1);
      stepperZeroSettingStepC[i] = false;
      stepperZeroSettingStepD[i] = true;
      stepperZeroSettingTimeD[i] = millis();
#ifdef STEPPER_DEBUG
      Serial.println("c-d");
#endif
    }

    if (stepperZeroSettingStepD[i] == true && stepper[i].distanceToGo() == 0
        && (millis() - stepperZeroSettingTimeD[i]) > STEPPER_ZERO_SETTING_DEAD_TIME_D) {
      if (digitalRead(stepperOptronPin[i]) == LOW) {
        stepper[i].move(-1);
        stepperZeroSettingStepD[i] = false;
        stepperZeroSettingStepE[i] = true;
#ifdef STEPPER_DEBUG
        Serial.println("d-e");
#endif
      }
      else {
        stepperZeroSettingStepD[i] = false;
        stepperZeroSettingStepC[i] = true;
#ifdef STEPPER_DEBUG
        Serial.println("d-c");
#endif
      }
    }

    if (stepperZeroSettingStepE[i] == true && stepper[i].distanceToGo() == 0) {

      stepper[i].setMaxSpeed(STEPPER_SPEED);
      stepper[i].setSpeed(STEPPER_SPEED);
      stepper[i].setAcceleration(STEPPER_ACCELERATION);

      stepperZeroSettingStepE[i] = false;
      stepperZeroPos[i] = stepper[i].currentPosition();
#ifdef STEPPER_SETUP
      stepperBuzy[i] = false;
      Serial.print(i);
      Serial.print("#");
      Serial.print("*=");
      Serial.print("#");
      Serial.print(stepperZeroPos[i]);
      Serial.print("#");
      Serial.print(i);
      Serial.println("-=0");
#endif
#ifndef STEPPER_SETUP
      stepperZeroSettingStepF[i] = true;
      stepper[i].move(stepperTrueZeroPos[i]);
#ifdef STEPPER_DEBUG
      Serial.println("d-f");
#endif
#endif
    }

#ifndef STEPPER_SETUP
    if (stepperZeroSettingStepF[i] == true & stepper[i].distanceToGo() == 0) {
      stepperZeroSettingStepF[i] = false;
      stepperBuzy[i] = false;

      //        Serial.print(arduinoSymbol);
      //        Serial.print(stepperSymbol);
      //        if(i < 10){
      //          Serial.print(0);
      //        }
      //        Serial.print(i);
      //        Serial.print(0);
      //        Serial.println(endSymbol);
      if (i == (STEPPER_NUM - 1))
      {
        Serial.println("stop");
      }

    }

    //        СДВИГ СТРЕЛКИ ШАГОВЫХ ДВИГАТЕЛЕЙ                                    //

    if (stepperMoveStepA[i] == true && stepperBuzy[i] == false) {
      stepper[i].moveTo(stepperZeroPos[i] + stepperTrueZeroPos[i] + stepperPos[i]);
      stepperMoveStepA[i] = false;
      //    stepperMoveStepB[i] = true;
    }

    /*     if(stepperMoveStepB[i] == true && stepper[i].distanceToGo() == 0){
           stepperMoveStepB[i] = false;
           Serial.print(arduinoSymbol);
           Serial.print(stepperSymbol);
           if(i < 10){
             Serial.print(0);
           }
           Serial.print(i);
           Serial.print(stepperPos[i]);
           Serial.println(endSymbol);
         }*/
#endif
  }
  /////////////////////////////////

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

  #ifdef ENCSETUP
    for(i = 0; i < ENCNUM; i++){
      if (rawPos[i] != oldRawPos[i]){ // Вывод текущего положения энкодера при наличии изменений
        oldRawPos[i] = rawPos[i];     
        Serial.print("e");
        Serial.print("#");
        Serial.print(i);
        Serial.print("#");

        Serial.println(int(rawPos[i]));
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
            Serial.print("#");
            Serial.print(i);
            Serial.print("#");

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
          
          if(encType[i] == 3){
            encPos[i] = round((1 - encPos[i]) * (encBorder[i][1] - encBorder[i][0]));
            if(encPos[i] == encBorder[i][1]){
              encPos[i] = encBorder[i][0];
            }
          }
          
          if(encPos[i] != oldEncPos[i]){
            oldEncPos[i] = encPos[i];
            Serial.print("e");
            Serial.print("#");
            Serial.print(i);
            Serial.print("#");

            Serial.print(int(encPos[i]));
            Serial.println(" ");
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

   if (Serial.available() > 0){ // Проверка, что есть данные от ПК
    str = Serial.readStringUntil('\n');
#ifdef DEBUG
    //  Serial.print("USER: ");
    //  Serial.println(str);
#endif

////                                                                            ////
//        СВЯЗЬ С ПК ДЛЯ ДВУХПОЗИЦИОННЫХ ТУМБЛЕРОВ                                //
////                                                                            ////
   
    if (str.substring(0, 4).equals("togg")){ // Принудительный опрос тумблеров
      i = str.substring(4, 7).toInt();
      if(digitalRead(toggIn1[i]) == HIGH && digitalRead(toggIn2[i]) == HIGH){
    /*    Serial.print("t");
        Serial.print(i);
        Serial.println(" off");  */
      }
      else if(digitalRead(toggIn1[i]) == LOW){
 /*       Serial.print("t");
        Serial.print(i);
        Serial.println(" H");  */
      }
      else if(digitalRead(toggIn2[i]) == LOW){
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
   
    if (str.substring(0, 4).equals("conn")){// Принудительный опрос разъема
      i = str.substring(4, 6).toInt();
      if(i < CONNNUM){
        if(connPos[i] == false){
          /*Serial.print("c");
          Serial.print(i);
          Serial.print(" off");
          Serial.println("z");  */
        }
        else if(connPos[i] == true){
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

  


    ///////////////////////////////////////////////////NeoPixelBus Serial.available ////////////////////////////////////////
     if(str.substring(0, 2).equals("on")){
     if(str.substring(2, 3) != ""){
        i = str.substring(2, 5).toInt();  
        strip.SetPixelColor(i, hslWhite);
        strip.Show();
        }else{   
          for(i = 0; i < PixelCount; i++){
          strip.SetPixelColor(i, hslWhite);
          strip.Show();
        }
       }
      }
      else if(str.substring(0, 3).equals("off")){
     if(str.substring(3, 4) != ""){
        i = str.substring(3, 5).toInt();  
        strip.SetPixelColor(i, hslBlack);
        strip.Show();
        }else{
           for(i = 0; i < PixelCount; i++){
          strip.SetPixelColor(i, hslBlack);
          strip.Show();
        }
        } 
      }
    
    ///////////////////////////////////////////////////NeoPixelBus Serial.available ////////////////////////////////////////
    
    
    

    ////////////////////СВЯЗЬ МОТОРОВ////////////////////
#ifdef STEPPER_SETUP
    if (str.substring(1, 2).equals("+") && stepperBuzy[i] == false) {
      // Принудительная установка нуля
      stepperZeroSettingStepA[str.substring(0, 1).toInt()] = true;
    }
    else if (str.substring(1, 2).equals("*")) { // Принудительный абсолютный сдвиг стрелки
      stepper[str.substring(0, 1).toInt()].moveTo(str.substring(2, 13).toInt());
#ifdef STEPPER_DEBUG
      Serial.println(digitalRead(stepperOptronPin[str.substring(0, 1).toInt()]));
#endif
    }
    else if (str.substring(1, 2).equals("-")) { // Принудительный относительный сдвиг стрелки
      i = str.substring(0, 1).toInt();
      stepper[i].moveTo(str.substring(2, 13).toInt() + stepperZeroPos[i]);
    }
#endif

    if (str.substring(0, 1).equals("s")) {

      ////                                                                      ////
      //        СВЯЗЬ ДЛЯ ДВИГАТЕЛЯ                                               //
      ////                                                                      ////

#ifndef STEPPER_SETUP
      if (str.substring(1, 2).equals(stepperSymbol) && str.substring(4, 5).equals("+")) {
        // Принудительная установка нуля
        stepperZeroSettingStepA[str.substring(2, 4).toInt()] = true;
      }
      else if (str.substring(0, 1).equals("s")) {
        // Принудительный относительный сдвиг стрелки
        i = str.substring(1, 2).toInt();
        char myChar[11];
        str.substring(6, 10).toCharArray(myChar, 11);
        j2 = atol(myChar);
        
        //j2 = j2 * 4;
        //Serial.println(j2);
        if (j2 >= stepperBorder[i][0] && j2 <= stepperBorder[i][1]) {
          stepperPos[i] = j2;
          stepperMoveStepA[i] = true;
#ifdef STEPPER_DEBUG
          Serial.println(digitalRead(stepperOptronPin[i]));
#endif
        }
      }
      else if (str.substring(1, 2).equals(stepperSymbolB)) {
        // Принудительный относительный сдвиг стрелки
        i = str.substring(2, 4).toInt();
        if (i != 0) {
          char myChar[11];
          str.substring(4, 15).toCharArray(myChar, 11);
          j2 = atol(myChar);
          /*
            if(j >= stepperBorder[i][0] && j <= stepperBorder[i][1]){
            stepperPos[i] += j;
            stepperMoveStepA[i] = true;
            }
          */
          if (j2 >= 0 && j2 <= 800) {
            if (j2 == 800) {
              j2 = 0;
            }
            long myI;
            myI = stepperPos[i] / 800;
            if (abs(j2 + 800 * myI - stepperPos[i]) < 400) {
              stepperPos[i] = j2 + 800 * myI;
            }
            else if (abs(j2 + 800 * (myI + 1) - stepperPos[i]) < 400) {
              stepperPos[i] = j2 + 800 * (myI + 1);
            }
            else if (abs(j2 + 800 * (myI - 1) - stepperPos[i]) < 400) {
              stepperPos[i] = j2 + 800 * (myI - 1);
            }
            else if (abs(j2 + 800 * (myI + 2) - stepperPos[i]) < 400) {
              stepperPos[i] = j2 + 800 * (myI + 2);
            }
            else if (abs(j2 + 800 * (myI - 2) - stepperPos[i]) < 400) {
              stepperPos[i] = j2 + 800 * (myI - 2);
            }
            stepperMoveStepA[i] = true;
          }

        }
      }
#endif

    }

////                                                                            ////
//        СВЯЗЬ С ПК ДЛЯ ЭНКОДЕРОВ                                                //
////                                                                            ////

    else if(str.substring(0, 3).equals("enc")){ // Запрос состояния энкодера от ПК и вывод в порт ПК
      i = str.substring(3, 4).toInt();
      if(i < ENCNUM){
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

  for (i = 0; i < STEPPER_NUM; i++) {
    if (stepperZeroSettingLock[i] == false) {
      stepper[i].run();
    }
#ifdef STEPPER_DEBUG
    if (stepper[i].currentPosition() != stepperDebugPos[i]) {
      stepperDebugPos[i] = stepper[i].currentPosition();
     // Serial.println(stepperDebugPos[i]);
    }
#endif
  }
  
}
