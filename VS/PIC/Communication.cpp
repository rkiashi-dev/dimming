// PIC.cpp : コンソール アプリケーションのエントリ ポイントを定義します。
//

#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <memory.h>
#include <string.h>
#include <ctype.h>
#include <stdlib.h>

#define MAX_MSG_SIZE 30

typedef unsigned char UCHAR;
typedef unsigned short UWORD;

const UCHAR TEL_HEADER[] = { '@', '\0' };
const UCHAR TEL_DELIMITER[] = { '\r', '\n', '\0' };
const UCHAR TEL_OK[] = { 'O', '\0' };
const UCHAR TEL_NG[] = { 'N', '\0' };


const UCHAR TEL_ALL_CHANNEL[] = { 255 };

enum NG_REASON {
	NONE = 0x00,
	INVALID_COMMAND = 0x01,
	INVALID_CHECKSUM = 0x02,
	ERROR_RANGE = 0x03
};


typedef struct _message {
	UCHAR body[MAX_MSG_SIZE];
	int length;
} message;

UCHAR highword(UWORD num) {
	return (UCHAR)((num & 0xFF00) >> 8);
}
UCHAR lowword(UWORD num) {
	return (UCHAR)((num & 0x00FF));
}

UCHAR calcCS(UCHAR* data, int len) {

	// ヘッダから送信コマンド最後（チェックサムとデリミタの前）までを加算
	// 加算後の下位1バイトを採用

	UWORD cs = 0;

	for (int i = 0; i < len; i++) {
		cs += data[i];
	}

	return lowword(cs) ;
}

int checkCS(UCHAR* data, int len, UCHAR cs) {
	UCHAR calc = calcCS(data, len);

	return calc == cs;
}

message makeChoukouData(UCHAR channel, bool isOK, NG_REASON reason) {
	char buf[MAX_MSG_SIZE];
	memset(buf, 0x00, sizeof(buf));

	char tmp[3];
	memset(tmp, 0x00, sizeof(tmp));
	snprintf(tmp, 3, "%02d", channel);

	strcat(buf, (const char*)TEL_HEADER);
	strcat(buf, tmp);

	if (isOK) {
		strcat(buf, (const char*)TEL_OK);
	}
	else {
		strcat(buf, (const char*)TEL_NG);
		memset(tmp, 0x00, sizeof(tmp));
		snprintf(tmp, 3, "%02d", reason);
		strcat(buf, tmp);
	}

	int len = strlen(buf);
	UCHAR cs = calcCS((UCHAR*)buf, len);
	memset(tmp, 0x00, sizeof(tmp));
	snprintf(tmp, 3, "%02d", cs);
	strcat(buf, tmp);
	strcat(buf, (const char*)TEL_DELIMITER);

	message m;
	strcpy((char*)m.body, buf);
	m.length = strlen(buf);

	return m;
}

message makeHakkouMode(UCHAR channel, bool isOK, NG_REASON reason) {
	return makeChoukouData(channel, isOK, reason);
}

message makeOnOff(UCHAR channel, bool isOK, NG_REASON reason) {
	return makeChoukouData(channel, isOK, reason);
}

message makeSettings(UCHAR channel, bool isOK, NG_REASON reason, int choukou, int sutorobo, bool off) {
	char buf[MAX_MSG_SIZE];
	memset(buf, 0x00, sizeof(buf));

	char tmp[4];
	memset(tmp, 0x00, sizeof(tmp));
	snprintf(tmp, 3, "%02d", channel);

	strcat(buf, (const char*)TEL_HEADER);
	strcat(buf, tmp);

	if (isOK) {
		strcat(buf, (const char*)TEL_OK);
		strcat(buf, "F");
		memset(tmp, 0x00, sizeof(tmp));
		snprintf(tmp, 4, "%03d", choukou);
		strcat(buf, tmp);
		strcat(buf, ".S");
		memset(tmp, 0x00, sizeof(tmp));
		snprintf(tmp, 3, "%02d", sutorobo);
		strcat(buf, tmp);
		strcat(buf, ".L");
		memset(tmp, 0x00, sizeof(tmp));
		snprintf(tmp, 2, "%01d", off ? 0x00 : 0x01);
		strcat(buf, tmp);
	}
	else {
		strcat(buf, (const char*)TEL_NG);
		memset(tmp, 0x00, sizeof(tmp));
		snprintf(tmp, 3, "%02d", reason);
		strcat(buf, tmp);
	}

	int len = strlen(buf);
	UCHAR cs = calcCS((UCHAR*)buf, len);
	memset(tmp, 0x00, sizeof(tmp));
	snprintf(tmp, 3, "%02d", cs);
	strcat(buf, tmp);
	strcat(buf, (const char*)TEL_DELIMITER);

	message m;
	strcpy((char*)m.body, buf);
	m.length = strlen(buf);

	return m;
}

message makeJyoutai(bool isOK, NG_REASON reason, bool jyoutai) {
	char buf[MAX_MSG_SIZE];
	memset(buf, 0x00, sizeof(buf));

	char tmp[3];
	memset(tmp, 0x00, sizeof(tmp));
	snprintf(tmp, 3, "%02d", 0);

	strcat(buf, (const char*)TEL_HEADER);
	strcat(buf, tmp);

	if (isOK) {
		strcat(buf, (const char*)TEL_OK);
		memset(tmp, 0x00, sizeof(tmp));
		snprintf(tmp, 3, "%02d", jyoutai ? 0 : 11);
		strcat(buf, tmp);
	}
	else {
		strcat(buf, (const char*)TEL_NG);
		memset(tmp, 0x00, sizeof(tmp));
		snprintf(tmp, 3, "%02d", reason);
		strcat(buf, tmp);
	}

	int len = strlen(buf);
	UCHAR cs = calcCS((UCHAR*)buf, len);
	memset(tmp, 0x00, sizeof(tmp));
	snprintf(tmp, 3, "%02d", cs);
	strcat(buf, tmp);
	strcat(buf, (const char*)TEL_DELIMITER);

	message m;
	strcpy((char*)m.body, buf);
	m.length = strlen(buf);

	return m;
}


#ifndef _XXXX


int xxx = 0;

char timed_getc() {
	const char* debug = "@01F00024\r\n";
	return debug[xxx++];
}
void delay_us(int s) {
	//sleep( s ) ;
}

#endif /* */

void printMessage(message* m)
{

	int zzz = 0;

	printf("===== message =====\n");
	printf("Length      : %d\n", (*m).length);
	printf("CheckSum    : %c%c\n", (*m).body[(*m).length - 4], (*m).body[(*m).length - 3]);

	for (zzz = 0; zzz < ((*m).length); zzz++) {
		UCHAR a = (*m).body[zzz];
		if (isprint(a)) {
			printf("(%c)", a);
		}
		else {
			printf("(.)");
		}
		printf("[0x%02x]", a);
	}
	printf("\n");
}

void sendMessage(message m) {
	printMessage(&m);
}

void procChoukou(int channel, int data) {
	//TODO:
	sendMessage(makeChoukouData(channel, true, NONE));
}
void procHakkou(int channel, int data) {
	//TODO:
	sendMessage(makeHakkouMode(channel, true, NONE));
}
void procOnOff(int channel, int data) {
	//TODO:
	sendMessage(makeOnOff(channel, true, NONE));
}
void procSettings(int channel) {
	//TODO:
	sendMessage(makeSettings(channel, true, NONE, 0, 0, true));
}
void procJyoutai(int channel) {
	//TODO:
	sendMessage(makeJyoutai(true, NONE, true));
}

void recvMessage() {

	UCHAR buffer[MAX_MSG_SIZE];
	int index = 0;
	UCHAR inChar;

	message m;
	UCHAR lrc;

	// 経過 msec
	int elapsedMSec = 0;

	while (1) {
		inChar = timed_getc();
		if (inChar != TEL_HEADER[0]) {
			elapsedMSec += 10;
			delay_us(10);

			// 100msec 経過
			if (elapsedMSec > 100) {
				return;
			}
			continue;
		}

		memset(buffer, 0x00, sizeof(buffer));
		buffer[0] = TEL_HEADER[0];

		char ch[3] = { 0x00,0x00,0x00 };
		ch[0] = timed_getc();
		ch[1] = timed_getc();
		int channel = atoi(ch);
		buffer[1] = ch[0];
		buffer[2] = ch[1];

		inChar = timed_getc();
		buffer[3] = inChar;
		switch (inChar) {
		case 'F': 
			{
			char dt[4] = { 0x00, 0x00, 0x00, 0x00 };
			buffer[4] = dt[0] = timed_getc();
			buffer[5] = dt[1] = timed_getc();
			buffer[6] = dt[2] = timed_getc();
			int data = atoi(dt);

			char cs[3] = { 0x00, 0x00, 0x00 };
			cs[0] = timed_getc();
			cs[1] = timed_getc();

			int checksum = atoi(cs);
			if (!checkCS(buffer, strlen((const char*)buffer), checksum & 0x00FF)) {
				sendMessage(makeChoukouData(channel, false, INVALID_CHECKSUM));
				continue;
			}

			procChoukou(channel, data);
			}
			break;
		case 'S':
		{
			char dt[3] = { 0x00, 0x00, 0x00 };
			buffer[4] = dt[0] = timed_getc();
			buffer[5] = dt[1] = timed_getc();
			int data = atoi(dt);

			char cs[3] = { 0x00, 0x00, 0x00 };
			cs[0] = timed_getc();
			cs[1] = timed_getc();

			int checksum = atoi(cs);
			if (!checkCS(buffer, strlen((const char*)buffer), checksum & 0x00FF)) {
				sendMessage(makeHakkouMode(channel, false, INVALID_CHECKSUM));
				continue;
			}

			procHakkou(channel, data);
		}
		break;
		case 'L':
		{
			char dt[2] = { 0x00, 0x00 };
			buffer[4] = dt[0] = timed_getc();
			int data = atoi(dt);

			char cs[3] = { 0x00, 0x00, 0x00 };
			cs[0] = timed_getc();
			cs[1] = timed_getc();

			int checksum = atoi(cs);
			if (!checkCS(buffer, strlen((const char*)buffer), checksum & 0x00FF)) {
				sendMessage(makeOnOff(channel, false, INVALID_CHECKSUM));
				continue;
			}

			procOnOff(channel, data);
		}
		break;
		case 'M':
		{
			char cs[3] = { 0x00, 0x00, 0x00 };
			cs[0] = timed_getc();
			cs[1] = timed_getc();

			int checksum = atoi(cs);
			if (!checkCS(buffer, strlen((const char*)buffer), checksum & 0x00FF)) {
				sendMessage(makeSettings(channel, false, INVALID_CHECKSUM,0,0,false));
				continue;
			}

			procSettings(channel);
		}
		break;
		case 'C':
		{
			char cs[3] = { 0x00, 0x00, 0x00 };
			cs[0] = timed_getc();
			cs[1] = timed_getc();

			int checksum = atoi(cs);
			if (!checkCS(buffer, strlen((const char*)buffer), checksum & 0x00FF)) {
				sendMessage(makeJyoutai(false, INVALID_CHECKSUM,false));
				continue;
			}

			procJyoutai(channel);
		}
		break;
		}
	}
}


int main() {

	recvMessage();

	message m1 = makeChoukouData(0, true, NONE);
	printMessage(&m1);

	message m2 = makeSettings(0, true, NONE, 255, 10, false);
	printMessage(&m2);
	
	message m3 = makeJyoutai(true, NONE, false);
	printMessage(&m3);

	return 0;
}