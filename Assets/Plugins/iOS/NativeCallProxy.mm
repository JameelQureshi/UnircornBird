#import <Foundation/Foundation.h>
#import "NativeCallProxy.h"


@implementation FrameworkLibAPI

id<NativeCallsProtocol> api = NULL;
+(void) registerAPIforNativeCalls:(id<NativeCallsProtocol>) aApi
{
    api = aApi;
}

@end


extern "C" {

    void SwitchToNativeWindow(const char* color) { return [api SwitchToNativeWindow:[NSString stringWithUTF8String:color]]; }

    void UnloadUnity() { return [api UnloadUnity]; }
}

