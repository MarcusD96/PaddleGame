// AgvSpdSpc.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "Stats.h"


STATS_API void DefaultStats() {
	Agv = 1;
	Spd = 1;
	Spc = 1;
}

STATS_API float GetStat(int statNum_) {
	switch (statNum_)
	{
	case 0:
		return Agv;
		break;
	case 1:
		return Spd;
		break;
	case 2:
		return Spc;
		break;
	default:
		return 0;
		break;
	}
}
STATS_API void SetStat(int statNum_, int numStat_) {
	switch (statNum_)
	{
	case 0:
		Agv += numStat_;
		break;
	case 1:
		Spd += numStat_;
		break;
	case 2:
		Spc += numStat_;
		break;
	default:
		break;
	}
}