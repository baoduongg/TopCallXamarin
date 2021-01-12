using System;
using ObjCRuntime;

namespace NativeLibrary
{
    [Native]
    public enum PhoneSignalingTransport : long /* nint */
    {
        Udp = 0,
        Tcp,
        Tls
    }

    [Native]
    public enum PhoneCodecType : long /* nint */
    {
        Unsupported = 0,
        Audio,
        Video
    }

    [Native]
    public enum PhoneVideoOrientation : long /* nint */
    {
        Portrait = 0,
        PortraitUpsideDown,
        LandscapeRight,
        LandscapeLeft
    }

    [Native]
    public enum PhoneInitializeState : long /* nint */
    {
        Start = 0,
        Info,
        Warning,
        Success,
        Fail
    }

    [Native]
    public enum PhoneAudioVideoCodec : long /* nint */
    {
        None = 0,
        Amr,
        Gsm,
        Pcma,
        Pcmu,
        Ilbc,
        Speex,
        Bv16,
        Bv32,
        Evrc,
        G729ab,
        G722,
        G7221,
        Silk,
        H261,
        H263,
        H263p,
        H263pp,
        H264Bp10,
        H264Bp20,
        H264Bp30,
        H264Svc,
        Theora,
        Mp4vesEs,
        Vp8,
        Opus,
        Count
    }

    [Native]
    public enum PhoneBuddyStatus : long /* nint */
    {
        Unknown = 0,
        Online,
        Offline,
        Busy,
        Away
    }

    [Native]
    public enum PhoneNetworkEventType : long /* nint */
    {
        NotReachable = 0,
        PhoneNetworkEventReachableViaWiFi
    }

    [Native]
    public enum PhoneAudioRoute : long /* nint */
    {
        PhoneAudioRouteEarpeace = 0,
        PhoneAudioRouteSpeaker,
        PhoneAudioRouteBluetooth
    }

}

