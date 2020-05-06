#include "stdafx.h"
#include "TestAI.h"

TEST_API float FollowB(float _BY, float _EY, float _Sped) {
	if(_BY >= _EY) {
		if(_Sped >= 0) {
			return  _Sped;
		} else {
			return -_Sped;
		}
	} else {
		if(_Sped >= 0) {
			return  -_Sped;
		} else {
			return _Sped;
		}
	}
}