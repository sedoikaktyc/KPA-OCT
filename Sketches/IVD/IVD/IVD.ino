////////////////////////////////////////////////////////////////////////////////////
////////                                                                    ////////
////                                                                            ////
//        БИБЛИОТЕКИ                                                              //
////                                                                            ////
////////                                                                    ////////
////////////////////////////////////////////////////////////////////////////////////
////                                                                            ////
//        БИБЛИОТЕКИ ШАГОВЫХ ДВИГАТЕЛЕЙ                                           //
////                                                                            ////

// БИБЛИОТЕКА НЕ ПОДДЕРЖИВАЕТ МАССИВЫ ДВИГАТЕЛЕЙ, ЕСЛИ ИЗМЕНИТСЯ КОЛИЧЕСТВО
// ДВИГАТЕЛЕЙ, ИЗМЕНЕНИЯ БУДУТ И В "НАСТРОКАХ", И В "РАБОТЕ", И В "СВЯЗИ С ПК"
#include <AccelStepper.h>
#include <MCP3017AccelStepper.h>

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

///////////////////////////////////ПЕРЕМЕННЫЕ МОНИТОРОВ/////////////////////////////
// Подключаем библиотеку для работы с дисплеем
#include <QuadDisplay2.h>
#define MONNUM 5 // ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО МОНИТОРОВ!

const int dconst[MONNUM] = {760, 580, 170, 0, 200}; 
int d[MONNUM] = {760, 580, 170, 0, 200};

QuadDisplay disp0(19, 18, 17); // ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО МОНИТОРОВ! (CS, DI, ⎍)
QuadDisplay disp1(16, 15, 14);
QuadDisplay disp2(4, 3, 2);
QuadDisplay disp3(7, 6, 5);
QuadDisplay disp4(10, 9 ,8);

////////////////////////////////////////////////////////////////////////////////////

////                                                                            ////
//        ПЕРЕМЕННЫЕ ПРЕДОХРАНИТЕЛЕЙ                                              //
////                                                                            ////

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ПРЕДОХРАНИТЕЛЕЙ!
#define FUSENUM 3

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ПРЕДОХРАНИТЕЛЕЙ!
const byte fuseIn[] = {53, 42, 44}; // Пины предохранителей
bool fuseLog[] = {false, false, false}; // Переменная для определения изменений в положении предохранителей

///////////////////////////////////////////////////NeoPixelBus befor setup ////////////////////////////////////////
#include <NeoPixelBus.h>

const uint16_t PixelCount = 10; // this example assumes 4 pixels, making it smaller will cause a failure
const uint8_t PixelPin = 13;  // make sure to set this to the correct pin, ignored for Esp8266

bool ledCurrentState[] = {false,false,false,false,false,false,false,false,false,false};

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

///////////////////////Кнопки и тумблеры 2////////////////////////////
////2 позиции////
String  character_C = "b";
// Задержка
#define BUTTDELAY_C 50
// Количество кнопок
#define BUTTNUM_C 2
// количество кнопок перед указанными
int butADD_C = 0;
const byte buttPin_C[BUTTNUM_C] = {11,12};
// Положение кнопки
boolean buttPos_C[BUTTNUM_C] = {false,false};
// Реверс кнопки
boolean buttRev_C[BUTTNUM_C] = {false,false};
// Момент времени изменения положения кнопки
unsigned long buttTime_C[BUTTNUM_C] = {0,0};
// новый вариант строки
bool NEWstring = true;
////////////////////////////////////////////////////////////////////////////

////                                                                            ////
//        ПЕРЕМЕННЫЕ РАЗЪЕМОВ ШР                                                  //
////                                                                            ////

#define CONNDELAY0 50 // Время между двумя изменениями
#define CONNDELAY1 4000 // Время между двумя изменениями (для закручивающихся)

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО РАЗЪЕМОВ!
#define CONNNUM 3 // Количество разъемов

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО РАЗЪЕМОВ!
int connType[CONNNUM] = {0, 0, 0}; // Тип разъема
int connDelay[CONNNUM] = {0, 0, 0}; // Время между двумя изменениями

const byte connPin[CONNNUM] = {31, 43, 33}; // Пины разъемов

boolean connPos[CONNNUM] = {false, false, false}; // Положение разъемов

unsigned long connTime[CONNNUM] = {0, 0, 0}; // Момент времени изменения положения разъемов

////                                                                            ////
//        ПЕРЕМЕННЫЕ РАЗЪЕМОВ 2    - new                                            //
////                                                                            ////

//#define razSetup

#define razERROR 20 // Шум в значении потенциометра

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО РАЗЪЕМОВ 2!
#define razNUM 5

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО РАЗЪЕМОВ 2!
const byte razPin[razNUM] = {A0, A1, A2, A3, A4}; // Пины РАЗЪЕМОВ 2 {0, 1, 2}

int razPos[razNUM] = {0, 0, 0, 0, 0}; // Положение потенциометра

int oldrazPos[razNUM] = {0, 0, 0, 0, 0}; // Предыдущее положение потенциометра
int razType[razNUM] = {0, 0, 0, 0, 0}; // Тип потенциометра
int razBorder[razNUM][2] = {{0, 1000}, {0, 1000}, {0, 1000}, {0, 1000}, {0, 1000}};

int razAnswer[razNUM] = {960, 880, 820, 760, 720};

#define razERRORAnswer 15

// Границы значений потенциометра

double truerazPos[razNUM] = {0, 0, 0, 0, 0}; // Положение потенциометра по шкале
double oldTruerazPos[razNUM] = {0, 0, 0, 0, 0}; // Старое положение потенциометра по шкале

int truerazAnswer[razNUM] = {0, 0, 0, 0, 0}; // Положение потенциометра по шкале
int oldTruerazAnswer[razNUM] = {2, 2, 2, 2, 2}; // Старое положение потенциометра по шкале

unsigned long razTime[razNUM] = {0, 0, 0, 0, 0}; // Момент времени изменения положения кнопки

#define razDELAY 1000 // Время между двумя изменениями
#define razDELAYsetup 20 // Время между двумя изменениями


unsigned long traz = 0;

/////////////////////////////////// 2020 raz end

////                                                                            ////
//        ПЕРЕМЕННЫЕ ЭНКОДЕРОВ                                                    //
////                                                                            ////

//#define ENCSETUP // Раскомментировать для настройки

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
#define ENCNUM 7 // Количество энкодеров

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
const byte encoderAddress[ENCNUM]= {32, 38, 33, 34, 35, 36, 37}; // Адреса энкодеров

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
ACE128 enc0((uint8_t)encoderAddress[0], (uint8_t*)encoderMap_87654321); // Адрес и карта энкодера
ACE128 enc1((uint8_t)encoderAddress[1], (uint8_t*)encoderMap_87654321); // Адрес и карта энкодера
ACE128 enc2((uint8_t)encoderAddress[2], (uint8_t*)encoderMap_87654321); // Адрес и карта энкодера
ACE128 enc3((uint8_t)encoderAddress[3], (uint8_t*)encoderMap_87654321); // Адрес и карта энкодера
ACE128 enc4((uint8_t)encoderAddress[4], (uint8_t*)encoderMap_87654321); // Адрес и карта энкодера
ACE128 enc5((uint8_t)encoderAddress[5], (uint8_t*)encoderMap_87654321); // Адрес и карта энкодера
ACE128 enc6((uint8_t)encoderAddress[6], (uint8_t*)encoderMap_87654321); // Адрес и карта энкодера

uint8_t rawPos[ENCNUM] = {0, 0, 0, 0, 0, 0, 0}; // Текущее положение энкодера
uint8_t oldRawPos[ENCNUM] = {127, 127, 127, 127, 127, 127, 127}; // Предыдущее положение энкодера

#ifndef ENCSETUP
  int encType[ENCNUM] = {0, 0, 4, 4, 4, 4, 4}; // Тип энкодера
  int rawBorder[ENCNUM][2] = {{79, 55}, {65, 43}, {38, 37}, {115, 106}, {47, 47}, {62, 54}, {63, 63}}; // Границы положений энкодера
  int encBorder[ENCNUM][2] = {{0, 101}, {0, 5}, {0, 101}, {0, 101}, {0, 101}, {0, 101}, {0, 101}}; // Границы положений энкодера по шкале
  
  double encPoint[ENCNUM] = {0, 0, 0, 0, 0, 0, 0}; //
  double encPos[ENCNUM] = {0, 0, 0, 0, 0, 0, 0}; // Положение энкодера по шкале
  int encPosInt[ENCNUM] = {0, 0, 0, 0, 0, 0, 0};
  double oldEncPos[ENCNUM] = {0, 0, 0, 0, 0, 0, 0}; // Предыдущее положение энкодера по шкале
  double rawNorm[ENCNUM] = {0, 0, 0, 0, 0, 0, 0};
#endif

/////////////////////////////////////////MOTORY/////////////////////////////////////

//#define STEPPER_SETUP // Раскомментировать для настройки
//#define STEPPER_DEBUG //Раскомментировать для поиска ошибок

#define STEPPER_NUM 5 // Количество шаговых двигателей


MCP3017AccelStepper stepper[STEPPER_NUM] = { // Определение двигателей
  MCP3017AccelStepper (AccelStepper::HALF4WIRE, 22, 24, 26, 28),
  MCP3017AccelStepper (AccelStepper::HALF4WIRE, 23, 25, 27, 29),
  MCP3017AccelStepper (AccelStepper::HALF4WIRE, 46, 48, 50, 52),
  MCP3017AccelStepper (AccelStepper::HALF4WIRE, 47, 49, 51, 40),
  MCP3017AccelStepper (AccelStepper::HALF4WIRE, 35, 37, 39, 41)
};


const byte stepperOptronPin[STEPPER_NUM] = {30, 32, 34, 36, 38}; // Пины оптронов
String stepperSymbol = "s"; // Обозначение шаговых двигателей
String stepperSymbolB = "r";

#define STEPPER_ACCELERATION 8000 // Ускорение //-
#define STEPPER_SPEED 2400 // Скорость //- 2400

#define STEPPER_ACCELERATION_yst 400 // Ускорение //-
#define STEPPER_SPEED_yst 200 // Скорость //-

boolean stepperBuzy[STEPPER_NUM] = {false, false, false, false, false}; // Статус работы

/////////////

boolean stepperZeroSettingLock[STEPPER_NUM] = {false, false, false, false, false}; // Блокировка движения в конце loop(){}
boolean stepperZeroSettingStepA[STEPPER_NUM] = {false, false, false, false, false}; // Логические шаги установки нуля
boolean stepperZeroSettingStepB[STEPPER_NUM] = {false, false, false, false, false};
boolean stepperZeroSettingStepC[STEPPER_NUM] = {false, false, false, false, false};
boolean stepperZeroSettingStepD[STEPPER_NUM] = {false, false, false, false, false};
boolean stepperZeroSettingStepE[STEPPER_NUM] = {false, false, false, false, false};

unsigned long stepperZeroSettingTimeC[STEPPER_NUM] = {0, 0, 0, 0, 0}; // Измерение времени в логическом шаге
unsigned long stepperZeroSettingTimeD[STEPPER_NUM] = {0, 0, 0, 0, 0};

#define STEPPER_ZERO_SETTING_SPEED_B 100 // Скорость, выставляемая в логическом шаге
#define STEPPER_ZERO_SETTING_DEAD_TIME_C 50 // Время ожидания перед шагом
#define STEPPER_ZERO_SETTING_DEAD_TIME_D 50

long stepperZeroPos[STEPPER_NUM] = {0, 0, 0, 0, 0}; // Положение нуля

/////////////

#ifndef STEPPER_SETUP
boolean stepperZeroSettingStepF[STEPPER_NUM] = {false, false, false, false, false};
// Дополнительные логические шаги установки нуля
boolean stepperMoveStepA[STEPPER_NUM] = {false, false, false, false, false}; // Логические шаги сдвига
boolean stepperMoveStepB[STEPPER_NUM] = {false, false, false, false, false};

long stepperTrueZeroPos[STEPPER_NUM] = {3, 11, 18, 10, 10}; // Положение нуля шкалы
long stepperBorder[STEPPER_NUM][2] = {{-14401, 4401}, {-32800, 0}, {-13120, 0}, {0, 16000}, {0, 96001}}; // Границы шкалы
long stepperPos[STEPPER_NUM] = {0, 0, 0, 0, 0}; // Текущее положение
#endif

//////////////

#ifdef STEPPER_DEBUG
long stepperDebugPos[STEPPER_NUM] = {0, 0, 0, 0, 0};
#endif



////                                                                            ////
//        ОБЩИЕ ПЕРЕМЕННЫЕ                                                        //
////                                                                            ////

//#define DEBUG // Раскомментировать для отладки

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭЛЕМЕНТОВ!
#define ELEMNUM 16

String str = "";
int n = 0;
int i;
double j = 0;
long j2;
double m = 0;
unsigned long t = 0;
boolean checkElem = false;

/////////////////////////////////////////////////////////////////////////////////////////////
void setup() {

////////////////////////////////////////////////////////////////////////////////////
////////                                                                    ////////
////                                                                            ////
//        НАСТРОЙКИ                                                               //
////                                                                            ////
////////                                                                    ////////
////////////////////////////////////////////////////////////////////////////////////
  
  Serial.begin(115200); // Инициализация порта для работы с ПК
Serial.println("IVD");
Serial.println("complite");
  #ifdef DEBUG
 // Serial.println("DEBUG DEFINED");
  #endif

/////////////////////////////////НАСТРОЙКИ МОНИТОРОВ/////////////////////////////////

  disp0.begin(); // ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО МОНИТОРОВ!
  disp1.begin();
  disp2.begin();
  disp3.begin();
  disp4.begin();

/////////////////////////////////////////////////////////////////////////////////////

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

    

///////////////////////////////////////////////////NeoPixelBus setup ////////////////////////////////////////
    strip.Begin();
    strip.Show();
///////////////////////////////////////////////////NeoPixelBus setup ////////////////////////////////////////
   /*for(i = 0; i < PixelCount; i++){
          strip.SetPixelColor(i, hslWhite);
          strip.Show();
        }*/

  //        НАСТРОЙКИ КНОПОК                                                       //
  ////                                                                            ////
  for (i = 0; i < BUTTNUM_C; i++) {
    pinMode(buttPin_C[i], INPUT); // Настройка пина на вход
    digitalWrite(buttPin_C[i], HIGH); // Подтяжка пина к питанию
  }
  for (i = 0; i < BUTTNUM_C; i++) { // Опрос кнопок
    if (buttRev_C[i] == false) {
      if (digitalRead(buttPin_C[i]) == HIGH) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_C);
        Serial.print(" off");
        Serial.println("z");
        }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
      }
      else if (digitalRead(buttPin_C[i]) == LOW) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_C);
        Serial.print(" on");
        Serial.println("z");
        buttPos_C[i] = true;
         }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
        buttPos_C[i] = true;
          }
      }
    }
    else {
      if (digitalRead(buttPin_C[i]) == HIGH) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_C);
        Serial.print(" on");
        Serial.println("z");
        buttPos_C[i] = true;
         }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
        buttPos_C[i] = true;
          }
      }
      else if (digitalRead(buttPin_C[i]) == LOW) {
        if (!NEWstring){
        Serial.print("b");
        Serial.print(i + butADD_C);
        Serial.print(" off");
        Serial.println("z");
         }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
      }
    }
    n++;
  }

////                                                                            ////
//        НАСТРОЙКИ РАЗЪЕМОВ ШР                                                     //
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

////////////////////////////////// 2020 raz
//////////////НАСТРОЙКИ РАЗЪЕМОВ 2///////////////////

for (i = 0; i < razNUM; i++) { // Опрос потенциометров
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
      Serial.print(i + 3);
      Serial.print("#");
      Serial.println("1");

      truerazAnswer[i] = 1;
    } else {
      Serial.print("c");
      Serial.print("#");
      Serial.print(i + 3);
      Serial.print("#");
      Serial.println("0");

    }
    oldTruerazAnswer[i] = truerazAnswer[i];
#else

    Serial.print("c");
    Serial.print("#");
    Serial.print(i + 3);
    Serial.print("#");
    Serial.println(truerazPos[i]);


#endif


  }

  //////////////////////////////////////2020 raz end

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

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
  rawPos[0] = enc0.rawPos(); // Опрос энкодера
  rawPos[1] = enc1.rawPos();
  rawPos[2] = enc2.rawPos();
  rawPos[3] = enc3.rawPos();
  rawPos[4] = enc4.rawPos();
  rawPos[5] = enc5.rawPos();
  rawPos[6] = enc6.rawPos();
  
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
              encPos[i] = (int)1.00;
            }
            else{
              encPos[i] = (int)0.00;
            }
          }
          else{
            if((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])){
              encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
            }
            else if((rawPos[i] > -encPoint[i]) && (rawPos[i] <= rawBorder[i][0])){
              encPos[i] = (int)0.00;
            }
            else{
              encPos[i] = (int)1.00;
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
            encPos[i] = (int)1.00;
          }
          else{
            encPos[i] = (int)0.00;
          }
        }
  
        if(encType[i] == 0){
          encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
          encPosInt[i] = encPos[i];
        }
  
        if(encType[i] == 1){
          encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
          if(encPos[i] == encBorder[i][1]){
            encPos[i] = encBorder[i][0];
            encPosInt[i] = encPos[i];
          }
        }

        if(encType[i] == 4){
          encPos[i] = round(encPos[i] * 10);  // 100.0;
          encPosInt[i] = encPos[i];
        }
        
      }
      oldEncPos[i] = encPos[i];
      Serial.print("e");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println((int)encPosInt[i]);
      n++;
    }
  #endif

//////////////////////////////////////////НАСТРОЙКА МОТОРОВ///////////////////////////////////

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


    pinMode(stepperOptronPin[i], INPUT);

  }

  for (i = 0; i < STEPPER_NUM; i++) { // Настройка двигателей
    stepper[i].setMaxSpeed(STEPPER_SPEED);
    stepper[i].setSpeed(STEPPER_SPEED);
    stepper[i].setAcceleration(STEPPER_ACCELERATION);
  }

}

void loop() {

////////////////////////////////////////////////////////////////////////////////////
////////                                                                    ////////
////                                                                            ////
//        РАБОТА                                                                  //
////                                                                            ////
////////                                                                    ////////
////////////////////////////////////////////////////////////////////////////////////

  ////                                                                            ////
  //        РАБОТА ПРЕДОХРАНИТЕЛЕЙ                                                  //
  ////                                                                            ////

  for (int i = 0; i < FUSENUM; i++) { // Опрос предохранителей
    if (digitalRead(fuseIn[i]) == LOW && fuseLog[i] == false) {
      delay(500);
      Serial.print("f");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("1");
      fuseLog[i] = true;
    }
    else if (digitalRead(fuseIn[i]) == HIGH && fuseLog[i] == true) {
      delay(500);
      Serial.print("f");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("0");
      fuseLog[i] = false;
    }
  }

  //        РАБОТА КНОПОК                                                           //
  ////                                                                            ////
  for (int i = 0; i < BUTTNUM_C; i++) { // Опрос кнопок
    if (buttRev_C[i] == false) {
      if ((digitalRead(buttPin_C[i]) == HIGH) && (buttPos_C[i] == true)) {
        t = millis();
        if ((t - buttTime_C[i]) > BUTTDELAY_C) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_C);
          Serial.print(" off");
          Serial.println("z");
           }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
          buttTime_C[i] = t;
          buttPos_C[i] = false;
        }
      }
      else if ((digitalRead(buttPin_C[i]) == LOW) && (buttPos_C[i] == false)) {
        t = millis();
        if ((t - buttTime_C[i]) > BUTTDELAY_C) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_C);
          Serial.print(" on");
          Serial.println("z");
           }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
          }
          buttTime_C[i] = t;
          buttPos_C[i] = true;
        }
      }
    }
    else {
      if ((digitalRead(buttPin_C[i]) == HIGH) && (buttPos_C[i] == false)) {
        t = millis();
        if ((t - buttTime_C[i]) > BUTTDELAY_C) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_C);
          Serial.print(" on");
          Serial.println("z");
           }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("1");
        Serial.println(); 
          }
          buttTime_C[i] = t;
          buttPos_C[i] = true;
        }
      }
      else if ((digitalRead(buttPin_C[i]) == LOW) && (buttPos_C[i] == true)) {
        t = millis();
        if ((t - buttTime_C[i]) > BUTTDELAY_C) {
          if (!NEWstring){
          Serial.print("b");
          Serial.print(i + butADD_C);
          Serial.print(" off");
          Serial.println("z");
           }else{
        Serial.print(character_C);
        Serial.print("#");
        Serial.print(i + butADD_C);
        Serial.print("#");
        Serial.print("0");
        Serial.println(); 
          }
          buttTime_C[i] = t;
          buttPos_C[i] = false;
        }
      }
    }
  }

////                                                                            ////
//        РАБОТА РАЗЪЕМОВ ШР                                                      //
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

      //////////////////////////////////////2020 raz


 for (i = 0; i < razNUM; i++) { // Опрос потенциометров

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
              Serial.print(i + 3);
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
            Serial.print("#");
            Serial.print(i + 3);
            Serial.print("#");
            Serial.println(truerazPos[i]);



#endif



          }
        }
      }
      razTime[i] = traz;
    }

  }

      //////////////////////////////////////2020 raz end

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
  
  #ifdef ENCSETUP
    for(i = 0; i < ENCNUM; i++){
      if (rawPos[i] != oldRawPos[i]){ // Вывод текущего положения энкодера при наличии изменений
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
            encPosInt[i] = encPos[i];
          }
          
          if(encType[i] == 1){
            encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
            if(encPos[i] == encBorder[i][1]){
              encPos[i] = encBorder[i][0];
              encPosInt[i] = encPos[i];
            }
          }

          if(encType[i] == 4){
          encPos[i] = round(encPos[i] * 10);  // 100.0;
          encPosInt[i] = encPos[i];
        }
          
          if(encPos[i] != oldEncPos[i]){
            oldEncPos[i] = encPos[i];
            Serial.print("e");
            Serial.print("#");
            Serial.print(i);
            Serial.print("#");
            Serial.println(encPosInt[i]);
            
          }
        }
      }
    }
  #endif

///////////////////////////////////РАБОТА МОТОРОВ//////////////////////////////////

  for (i = 0; i < STEPPER_NUM; i++) {

    //        УСТАНОВКА НУЛЯ ШАГОВЫХ ДВИГАТЕЛЕЙ                                   //

    if (stepperZeroSettingStepA[i] == true) {
      if (digitalRead(stepperOptronPin[i]) == LOW) {
        ///
        // stepper[i].setMaxSpeed(400); //-
        ///

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
      Serial.print("*=");
      Serial.print(stepperZeroPos[i]);
      Serial.print(" ");
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
        disp0.displayInt(dconst[0]); // ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО МОНИТОРОВ!
        disp1.displayInt(dconst[1]);
        disp2.displayInt(dconst[2]);
        disp3.displayInt(dconst[3]);
        disp4.displayInt(dconst[4]);
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
    /*  Serial.print("USER: ");
      Serial.println(str); */
    #endif

    ////                                                                            ////
    //        СВЯЗЬ С ПК ДЛЯ ПРЕДОХРАНИТЕЛЕЙ                                          //
    ////                                                                            ////

    if (str.substring(0, 4).equals("fuse")) { // Принудительный опрос предохранителя
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

    ///////////////////////////////////////////////////NeoPixelBus Serial.available ////////////////////////////////////////
     if(str.substring(0, 2).equals("on")){
     if(str.substring(2, 3) != ""){
        i = str.substring(2, 5).toInt();  
        strip.SetPixelColor(i, hslWhite);
        strip.Show();
        ledCurrentState[i] = true;
        }else{   
          for(i = 0; i < PixelCount; i++){
          strip.SetPixelColor(i, hslWhite);
          strip.Show();
          ledCurrentState[i] = true;
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
          ledCurrentState[i] = false;
        }
        } 
      }
    
    ///////////////////////////////////////////////////NeoPixelBus Serial.available ////////////////////////////////////////

////                                                                            ////
//        СВЯЗЬ С ПК ДЛЯ РАЗЪЕМОВ ШР                                              //
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
        str.substring(6, 16).toCharArray(myChar, 11);
        j2 = atol(myChar);
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

  } ///END SVYAZ'
  
   for (i = 0; i < STEPPER_NUM; i++) {
    if (stepperZeroSettingLock[i] == false) {
      stepper[i].run();
      checkMotorCurrentStep(i,stepper[i].currentPosition());

    
    }
  if (stepper[i].distanceToGo() == 0) {

    
switch (i){
  case 0:
  if (!ledCurrentState[2]){
     strip.SetPixelColor(2, hslBlack);
 strip.Show();
 ledCurrentState[2] = true;
    
    }

  break;
  case 1:
  if (!ledCurrentState[1]){
 strip.SetPixelColor(1, hslBlack);
 strip.Show();
 ledCurrentState[1] = true;
  }
  break;
   case 2:
  if (!ledCurrentState[0]){
 strip.SetPixelColor(0, hslBlack);
 strip.Show();
 ledCurrentState[0] = true;
  }
  break;
   case 3:
  if (!ledCurrentState[8]){
 strip.SetPixelColor(8, hslBlack);
 strip.Show();
 ledCurrentState[8] = true;
  }
  break;
   case 4:
  if (!ledCurrentState[7]){
 strip.SetPixelColor(7, hslBlack);
 strip.Show();
 ledCurrentState[7] = true;
  }
  break;

  
  
  }
/*    
    checkMotorCurrentStep(i,stepper[i].currentPosition());

switch (i){
  case 0:
 strip.SetPixelColor(0, hslBlack);
 strip.Show();
  break;
  case 1:
 strip.SetPixelColor(1, hslBlack);
 strip.Show();
  break;
  
  
  }
 */
    }else{
      //Serial.println("off ");
      switch (i){
  case 0:
  if (ledCurrentState[2]){
     strip.SetPixelColor(2, hslWhite);
 strip.Show();
 ledCurrentState[2] = false;
    
    }

  break;
  case 1:
  if (ledCurrentState[1]){
 strip.SetPixelColor(1, hslWhite);
 strip.Show();
 ledCurrentState[1] = false;
  }
  break;
  case 2:
  if (ledCurrentState[0]){
 strip.SetPixelColor(0, hslWhite);
 strip.Show();
 ledCurrentState[0] = false;
  }
  break;
  case 3:
  if (ledCurrentState[8]){
 strip.SetPixelColor(8, hslWhite);
 strip.Show();
 ledCurrentState[8] = false;
  }
  break;
  case 4:
  if (ledCurrentState[7]){
 strip.SetPixelColor(7, hslWhite);
 strip.Show();
 ledCurrentState[7] = false;
  }
  break;

  
  
  }
      
      
      }

    
#ifdef STEPPER_DEBUG
    if (stepper[i].currentPosition() != stepperDebugPos[i]) {
      stepperDebugPos[i] = stepper[i].currentPosition();
      Serial.println(stepperDebugPos[i]);
    }
#endif
  } 
  
}

int curPosForMonitor;
void checkMotorCurrentStep(int stepper, int currentStep){
  
switch(stepper){
  case 0:
curPosForMonitor = dconst[0] + currentStep/80;
disp0.displayInt(curPosForMonitor);

  break;
  case 1:
curPosForMonitor = dconst[1] + currentStep/80;
disp1.displayInt(curPosForMonitor);

  break;

  case 2:
curPosForMonitor = dconst[2] + currentStep/80;
disp2.displayInt(curPosForMonitor);

  break;

  case 3:
curPosForMonitor = dconst[3] + currentStep/80;
disp3.displayInt(curPosForMonitor);

  break;

  case 4:
curPosForMonitor = dconst[4] + currentStep/80;
disp4.displayInt(curPosForMonitor);

  break;
  
  
  }


  
  
  }
