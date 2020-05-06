#pragma once
// Stats.h : Declares the exported functions for the DLL application.
//

#include <cstdlib>

#define STATS_API __declspec(dllexport)

float Agv = 1;
float Spd = 1;
float Spc = 1;

extern "C" STATS_API void DefaultStats();
extern "C" STATS_API float GetStat(int statNum_);
extern "C" STATS_API void SetStat(int statNum_, int numStat_);