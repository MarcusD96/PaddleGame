#pragma once

#include <cstdlib>

#define STATS_API __declspec(dllexport)

extern "C" STATS_API float Agv = 0;
extern "C" STATS_API float Spd = 0;
extern "C" STATS_API float Spc = 0;

extern "C" STATS_API void DefaultStats();

extern "C" STATS_API float GetStat(int statNum_);
extern "C" STATS_API void SetStat(int statNum_, int numStat_);