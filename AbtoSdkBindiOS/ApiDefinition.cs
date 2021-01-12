using System;

using UIKit;
using Foundation;
using ObjCRuntime;

namespace NativeLibrary
{
	[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const kBuddyId;
		[Field("kBuddyId", "__Internal")]
		NSString kBuddyId { get; }

		// extern NSString *const kBuddyUri;
		[Field("kBuddyUri", "__Internal")]
		NSString kBuddyUri { get; }

		// extern NSString *const kBuddyContact;
		[Field("kBuddyContact", "__Internal")]
		NSString kBuddyContact { get; }

		// extern NSString *const kBuddyStatus;
		[Field("kBuddyStatus", "__Internal")]
		NSString kBuddyStatus { get; }

		// extern NSString *const kBuddyStatusName;
		[Field("kBuddyStatusName", "__Internal")]
		NSString kBuddyStatusName { get; }

		// extern NSString *const kBuddySubState;
		[Field("kBuddySubState", "__Internal")]
		NSString kBuddySubState { get; }

		// extern NSString *const kBuddySubStateName;
		[Field("kBuddySubStateName", "__Internal")]
		NSString kBuddySubStateName { get; }

		// extern NSString *const kBuddySubTermCode;
		[Field("kBuddySubTermCode", "__Internal")]
		NSString kBuddySubTermCode { get; }

		// extern NSString *const kBuddySubTermName;
		[Field("kBuddySubTermName", "__Internal")]
		NSString kBuddySubTermName { get; }

		// extern NSString *const kBuddyRpidCode;
		[Field("kBuddyRpidCode", "__Internal")]
		NSString kBuddyRpidCode { get; }

		// extern NSString *const kBuddyPresence;
		[Field("kBuddyPresence", "__Internal")]
		NSString kBuddyPresence { get; }

		// extern NSInteger kInvalidCallId;
		[Field("kInvalidCallId", "__Internal")]
		nint kInvalidCallId { get; }
	}

	// @interface AbtoPhoneMediaQuality : NSObject
	[BaseType(typeof(NSObject))]
	interface AbtoPhoneMediaQuality
	{
		// @property (assign, nonatomic) NSInteger minRtt;
		[Export("minRtt")]
		nint MinRtt { get; set; }

		// @property (assign, nonatomic) NSInteger maxRtt;
		[Export("maxRtt")]
		nint MaxRtt { get; set; }

		// @property (assign, nonatomic) NSInteger avgRtt;
		[Export("avgRtt")]
		nint AvgRtt { get; set; }

		// @property (assign, nonatomic) NSInteger minBufferJitter;
		[Export("minBufferJitter")]
		nint MinBufferJitter { get; set; }

		// @property (assign, nonatomic) NSInteger maxBufferJitter;
		[Export("maxBufferJitter")]
		nint MaxBufferJitter { get; set; }

		// @property (assign, nonatomic) NSInteger avgBufferJitter;
		[Export("avgBufferJitter")]
		nint AvgBufferJitter { get; set; }

		// @property (assign, nonatomic) NSInteger devBufferJitter;
		[Export("devBufferJitter")]
		nint DevBufferJitter { get; set; }

		// @property (assign, nonatomic) NSInteger burstJitter;
		[Export("burstJitter")]
		nint BurstJitter { get; set; }

		// @property (assign, nonatomic) NSInteger avgBurstJitter;
		[Export("avgBurstJitter")]
		nint AvgBurstJitter { get; set; }

		// @property (assign, nonatomic) NSInteger rxPackets;
		[Export("rxPackets")]
		nint RxPackets { get; set; }

		// @property (assign, nonatomic) NSInteger txPackets;
		[Export("txPackets")]
		nint TxPackets { get; set; }
	}

	// @interface AbtoPhoneConfig : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	interface AbtoPhoneConfig : INSCopying
	{
		// @property (assign, nonatomic) PhoneSignalingTransport signalingTransport;
		[Export("signalingTransport", ArgumentSemantic.Assign)]
		PhoneSignalingTransport SignalingTransport { get; set; }

		// @property (assign, nonatomic) BOOL enableSrtp;
		[Export("enableSrtp")]
		bool EnableSrtp { get; set; }

		// @property (assign, nonatomic) BOOL enableZrtp;
		[Export("enableZrtp")]
		bool EnableZrtp { get; set; }

		// @property (assign, nonatomic) BOOL enableProxy;
		[Export("enableProxy")]
		bool EnableProxy { get; set; }

		// @property (assign, nonatomic) BOOL enableStun;
		[Export("enableStun")]
		bool EnableStun { get; set; }

		// @property (assign, nonatomic) BOOL enableIce;
		[Export("enableIce")]
		bool EnableIce { get; set; }

		// @property (assign, nonatomic) BOOL enableRingTone;
		[Export("enableRingTone")]
		bool EnableRingTone { get; set; }

		// @property (assign, nonatomic) BOOL enableRingBackTone;
		[Export("enableRingBackTone")]
		bool EnableRingBackTone { get; set; }

		// @property (assign, nonatomic) BOOL enableAutorotateCaptureDevice;
		[Export("enableAutorotateCaptureDevice")]
		bool EnableAutorotateCaptureDevice { get; set; }

		// @property (assign, nonatomic) BOOL enableDoubleReg;
		[Export("enableDoubleReg")]
		bool EnableDoubleReg { get; set; }

		// @property (assign, nonatomic) BOOL enableTLSVerifyServer;
		[Export("enableTLSVerifyServer")]
		bool EnableTLSVerifyServer { get; set; }

		// @property (assign, nonatomic) BOOL enableSipsSchemeUse;
		[Export("enableSipsSchemeUse")]
		bool EnableSipsSchemeUse { get; set; }

		// @property (assign, nonatomic) BOOL enableMwi;
		[Export("enableMwi")]
		bool EnableMwi { get; set; }

		// @property (assign, nonatomic) BOOL allowSrtp256;
		[Export("allowSrtp256")]
		bool AllowSrtp256 { get; set; }

		// @property (assign, nonatomic) BOOL enableVideoStream;
		[Export("enableVideoStream")]
		bool EnableVideoStream { get; set; }

		// @property (retain, nonatomic) NSString * ua;
		[Export("ua", ArgumentSemantic.Retain)]
		string Ua { get; set; }

		// @property (retain, nonatomic) NSString * stun;
		[Export("stun", ArgumentSemantic.Retain)]
		string Stun { get; set; }

		// @property (retain, nonatomic) NSString * proxy;
		[Export("proxy", ArgumentSemantic.Retain)]
		string Proxy { get; set; }

		// @property (retain, nonatomic) NSString * localIp;
		[Export("localIp", ArgumentSemantic.Retain)]
		string LocalIp { get; set; }

		// @property (retain, nonatomic) NSString * displayName;
		[Export("displayName", ArgumentSemantic.Retain)]
		string DisplayName { get; set; }

		// @property (retain, nonatomic) NSString * tlsCaList;
		[Export("tlsCaList", ArgumentSemantic.Retain)]
		string TlsCaList { get; set; }

		// @property (retain, nonatomic) NSString * ringToneUrl;
		[Export("ringToneUrl", ArgumentSemantic.Retain)]
		string RingToneUrl { get; set; }

		// @property (retain, nonatomic) NSString * ringBackToneUrl;
		[Export("ringBackToneUrl", ArgumentSemantic.Retain)]
		string RingBackToneUrl { get; set; }

		// @property (retain, nonatomic) NSString * regUser;
		[Export("regUser", ArgumentSemantic.Retain)]
		string RegUser { get; set; }

		// @property (retain, nonatomic) NSString * regDomain;
		[Export("regDomain", ArgumentSemantic.Retain)]
		string RegDomain { get; set; }

		// @property (retain, nonatomic) NSString * regAuthId;
		[Export("regAuthId", ArgumentSemantic.Retain)]
		string RegAuthId { get; set; }

		// @property (retain, nonatomic) NSString * regPassword;
		[Export("regPassword", ArgumentSemantic.Retain)]
		string RegPassword { get; set; }

		// @property (retain, nonatomic) NSString * regDigest;
		[Export("regDigest", ArgumentSemantic.Retain)]
		string RegDigest { get; set; }

		// @property (assign, nonatomic) int regExpirationTime;
		[Export("regExpirationTime")]
		int RegExpirationTime { get; set; }

		// @property (assign, nonatomic) int localPort;
		[Export("localPort")]
		int LocalPort { get; set; }

		// @property (assign, nonatomic) int hangupTimeout;
		[Export("hangupTimeout")]
		int HangupTimeout { get; set; }

		// @property (assign, nonatomic) int registerTimeout;
		[Export("registerTimeout")]
		int RegisterTimeout { get; set; }

		// @property (assign, nonatomic) int inviteTimeout;
		[Export("inviteTimeout")]
		int InviteTimeout { get; set; }

		// @property (assign, nonatomic) int rtpPort;
		[Export("rtpPort")]
		int RtpPort { get; set; }

		// @property (retain, nonatomic) NSString * contactDetails;
		[Export("ContactDetails", ArgumentSemantic.Retain)]
		string ContactDetails { get; set; }

		// @property (retain, nonatomic) NSString * contactDetailsUri;
		[Export("ContactDetailsUri", ArgumentSemantic.Retain)]
		string ContactDetailsUri { get; set; }

		// -(id)initWithConfig:(AbtoPhoneConfig *)config;
		[Export("initWithConfig:")]
		IntPtr Constructor(AbtoPhoneConfig config);

		// -(void)setCodecPriority:(PhoneAudioVideoCodec)idx priority:(NSInteger)priority;
		[Export("setCodecPriority:priority:")]
		void SetCodecPriority(PhoneAudioVideoCodec idx, nint priority);

		// -(NSInteger)codecPriority:(PhoneAudioVideoCodec)idx;
		[Export("codecPriority:")]
		nint CodecPriority(PhoneAudioVideoCodec idx);

		// -(BOOL)saveToUserDefaults:(NSString *)key;
		[Export("saveToUserDefaults:")]
		bool SaveToUserDefaults(string key);

		// -(void)setFromConfig:(AbtoPhoneConfig *)config;
		[Export("setFromConfig:")]
		void SetFromConfig(AbtoPhoneConfig config);

		// -(BOOL)loadFromUserDefaults:(NSString *)key;
		[Export("loadFromUserDefaults:")]
		bool LoadFromUserDefaults(string key);

		// +(NSString *)codecName:(PhoneAudioVideoCodec)idx;
		[Static]
		[Export("codecName:")]
		string CodecName(PhoneAudioVideoCodec idx);

		// +(PhoneCodecType)codecType:(PhoneAudioVideoCodec)idx;
		[Static]
		[Export("codecType:")]
		PhoneCodecType CodecType(PhoneAudioVideoCodec idx);

		// +(id)loadFromUserDefaults:(NSString *)key;
		//		[Static]
		//		[Export ("loadFromUserDefaults:")]
		//		NSObject LoadFromUserDefaults (string key);
	}

	// @protocol AbtoPhoneInterfaceObserver <NSObject>
	[Model, Protocol]
	[BaseType(typeof(NSObject))]
	interface AbtoPhoneInterfaceObserver
	{
		// @required -(void)onRegistered:(NSInteger)accId;
		[Abstract]
		[Export("onRegistered:")]
		void OnRegistered(nint accId);

		// @required -(void)onRegistrationFailed:(NSInteger)accId statusCode:(int)statusCode statusText:(NSString *)statusText;
		[Abstract]
		[Export("onRegistrationFailed:statusCode:statusText:")]
		void OnRegistrationFailed(nint accId, int statusCode, string statusText);

		// @required -(void)onUnRegistered:(NSInteger)accId;
		[Abstract]
		[Export("onUnRegistered:")]
		void OnUnRegistered(nint accId);

		// @required -(void)onRemoteAlerting:(NSInteger)accId statusCode:(int)statusCode;
		[Abstract]
		[Export("onRemoteAlerting:statusCode:")]
		void OnRemoteAlerting(nint accId, int statusCode);

		// @required -(void)onIncomingCall:(NSInteger)callId remoteContact:(NSString *)remoteContact;
		[Abstract]
		[Export("onIncomingCall:remoteContact:")]
		void OnIncomingCall(nint callId, string remoteContact);

		// @required -(void)onCallConnected:(NSInteger)callId remoteContact:(NSString *)remoteContact;
		[Abstract]
		[Export("onCallConnected:remoteContact:")]
		void OnCallConnected(nint callId, string remoteContact);

		// @required -(void)onCallDisconnected:(NSInteger)callId remoteContact:(NSString *)remoteContact statusCode:(NSInteger)statusCode message:(NSString *)message;
		[Abstract]
		[Export("onCallDisconnected:remoteContact:statusCode:message:")]
		void OnCallDisconnected(nint callId, string remoteContact, nint statusCode, string message);

		// @required -(void)onCallAlerting:(NSInteger)callId statusCode:(int)statusCode;
		[Abstract]
		[Export("onCallAlerting:statusCode:")]
		void OnCallAlerting(nint callId, int statusCode);

		// @required -(void)onCallHeld:(NSInteger)callId state:(BOOL)state;
		[Abstract]
		[Export("onCallHeld:state:")]
		void OnCallHeld(nint callId, bool state);

		// @required -(void)onToneReceived:(NSInteger)callId tone:(NSInteger)tone;
		[Abstract]
		[Export("onToneReceived:tone:")]
		void OnToneReceived(nint callId, nint tone);

		// @required -(void)onTextMessageReceived:(NSString *)from to:(NSString *)to body:(NSString *)body;
		[Abstract]
		[Export("onTextMessageReceived:to:body:")]
		void OnTextMessageReceived(string from, string to, string body);

		// @required -(void)onTextMessageStatus:(NSString *)address reason:(NSString *)reason status:(BOOL)status;
		[Abstract]
		[Export("onTextMessageStatus:reason:status:")]
		void OnTextMessageStatus(string address, string reason, bool status);

		// @required -(void)onPresenceChanged:(NSString *)uri status:(PhoneBuddyStatus)status note:(NSString *)note;
		[Abstract]
		[Export("onPresenceChanged:status:note:")]
		void OnPresenceChanged(string uri, PhoneBuddyStatus status, string note);

		// @required -(void)onTransferStatus:(NSInteger)callId statusCode:(int)statusCode message:(NSString *)message;
		[Abstract]
		[Export("onTransferStatus:statusCode:message:")]
		void OnTransferStatus(nint callId, int statusCode, string message);

		// @optional -(void)onZrtpSas:(NSInteger)callId sas:(NSString *)sas isVerified:(BOOL)verified;
		[Export("onZrtpSas:sas:isVerified:")]
		void OnZrtpSas(nint callId, string sas, bool verified);

		// @optional -(void)onZrtpSecureState:(NSInteger)callId secured:(BOOL)secured;
		[Export("onZrtpSecureState:secured:")]
		void OnZrtpSecureState(nint callId, bool secured);

		// @optional -(void)onZrtpError:(NSInteger)callId error:(NSInteger)error subcode:(NSInteger)subcode;
		[Export("onZrtpError:error:subcode:")]
		void OnZrtpError(nint callId, nint error, nint subcode);

		// @optional -(void)onNetworkStateChanged:(PhoneNetworkEvent)event isIpv6:(BOOL)ipv6;
		[Export("onNetworkStateChanged:isIpv6:")]
		void onNetworkStateChanged(PhoneNetworkEventType evt, bool ipv6);

		// @optional -(void)onMwiInfo:(NSInteger)accId withMimeType:(NSString * _Nonnull)type andText:(NSString * _Nonnull)text;
		[Export("onMwiInfo:withMimeType:andText:")]
		void onMwiInfo(nint callId, string type, string text);
	}

	// @interface AbtoPhoneInterface : NSObject
	[BaseType(typeof(NSObject))]
	interface AbtoPhoneInterface
	{
		// @property (readonly, nonatomic) NSString * libVersion;
		[Export("libVersion")]
		string LibVersion { get; }

		// -(BOOL)initialize:(id<AbtoPhoneInterfaceObserver> _Nonnull)observer;
		[Export("initialize:")]
		bool Initialize(AbtoPhoneInterfaceObserver observer);

		// - (BOOL)initialize:(id <AbtoPhoneInterfaceObserver> _Nonnull)observer withBackground:(BOOL)state;
		[Export("initialize:withBackground:")]
		bool Initialize(AbtoPhoneInterfaceObserver observer, bool background);

		// -(void)deinitialize;
		[Export("deinitialize")]
		void Deinitialize();

		// -(BOOL)finalizeConfiguration;
		[Export("finalizeConfiguration")]
		bool FinalizeConfiguration();

		// -(AbtoPhoneConfig * _Nonnull)config;
		[Export("config")]
		AbtoPhoneConfig Config { get; }

		// -(BOOL)unregister;
		[Export("unregister")]
		bool Unregister();

		// -(BOOL)keepAwake:(BOOL)enable;
		[Export("keepAwake:")]
		bool KeepAwake(bool enable);

		// -(NSInteger)startCall:(NSString * _Nonnull)destination withVideo:(BOOL)video;
		[Export("startCall:withVideo:")]
		nint StartCall(string destination, bool video);

		// -(NSInteger)startCall:(NSString * _Nonnull)destination withVideo:(BOOL)video andSipCallId:(NSString * _Nullable)sipCallId;
		[Export("startCall:withVideo:andSipCallId:")]
		nint StartCall(string destination, bool video, [NullAllowed] string sipCallId);

		// -(NSInteger)startCall:(NSString * _Nonnull)destination withVideo:(BOOL)video andSipCallId:(NSString * _Nullable)sipCallId andHeaders:(NSArray * _Nullable)headers;
		[Export("startCall:withVideo:andSipCallId:andHeaders:")]
		nint StartCall(string destination, bool video, [NullAllowed] string sipCallId, [NullAllowed] NSArray headers);

		// -(BOOL)answerCall:(NSInteger)callId status:(int)status withVideo:(BOOL)video;
		[Export("answerCall:status:withVideo:")]
		bool AnswerCall(nint callId, int status, bool video);

		// -(BOOL)hangUpCall:(NSInteger)callId status:(int)status;
		[Export("hangUpCall:status:")]
		bool HangUpCall(nint callId, int status);

		// -(BOOL)holdRetriveCall:(NSInteger)callId;
		[Export("holdRetrieveCall:")]
		bool HoldRetrieveCall(nint callId);

		// - (BOOL)updateCall:(NSInteger)callId mediaWithVideo:(BOOL)enabled;
		[Export("updateCall:mediaWithVideo:")]
		bool UpdateCallMediaWithVideo(nint callId, bool enabled);

		// - (BOOL)stopSendingAudio:(NSInteger)callId on:(BOOL)on;
		[Export("stopSendingAudio:on:")]
		bool StopSendingAudio(nint callId, bool on);

		// -(BOOL)setCall:(NSInteger)callId speakerLevel:(float)level;
		[Export("setCall:speakerLevel:")]
		bool SetCallSpeakerLevel(nint callId, float level);

		// -(BOOL)setCall:(NSInteger)callId microphoneLevel:(float)level;
		[Export("setCall:microphoneLevel:")]
		bool SetCallMicrophoneLevel(nint callId, float level);

		// -(BOOL)muteMicrophone:(NSInteger)callId on:(BOOL)on;
		[Export("muteMicrophone:on:")]
		bool MuteMicrophone(nint callId, bool on);

		// -(BOOL)sendTone:(NSInteger)callId tone:(unichar)tone;
		[Export("sendTone:tone:")]
		bool SendTone(nint callId, ushort tone);

		// -(BOOL)sendToneViaInfo:(NSInteger)callId tone:(unichar)tone;
		[Export("sendToneViaInfo:tone:")]
		bool SendToneViaInfo(nint callId, ushort tone);

		// -(BOOL)setBluetoothOn:(BOOL)on;
		[Export("setBluetoothOn:")]
		bool SetBluetoothOn(bool on);

		// -(BOOL)setSpeakerphoneOn:(BOOL)on;
		[Export("setSpeakerphoneOn:")]
		bool SetSpeakerphoneOn(bool on);

		// - (PhoneAudioRoute)currentAudioRoute;
		[Export("currentAudioRoute")]
		PhoneAudioRoute CurrentAudioRoute { get; }

		// -(BOOL)sendTextMessage:(NSString *)to withBody:(NSString * _Nonnull)message;
		[Export("sendTextMessage:withBody:")]
		bool SendTextMessage(string to, string message);

		// -(BOOL)transferCall:(NSInteger)callId toContact:(NSString * _Nonnull)uri;
		[Export("transferCall:toContact:")]
		bool TransferCall(nint callId, string uri);

		// -(BOOL)setPresence:(PhoneBuddyStatus)status statusText:(NSString * _Nonnull)text;
		[Export("setPresence:statusText:")]
		bool SetPresence(PhoneBuddyStatus status, string text);

		// -(BOOL)subscribeBuddy:(NSString * _Nonnull)uri on:(BOOL)on;
		[Export("subscribeBuddy:on:")]
		bool SubscribeBuddy(string uri, bool on);

		// -(void)setRemoteView:(UIImageView * _Nullable)view;
		[Export("setRemoteView:")]
		void SetRemoteView([NullAllowed] UIImageView view);

		// -(void)setLocalView:(UIImageView * _Nullable)view;
		[Export("setLocalView:")]
		void SetLocalView([NullAllowed] UIImageView view);

		// -(BOOL)isVideoCall:(NSInteger)callId;
		[Export("isVideoCall:")]
		bool IsVideoCall(nint callId);

		// -(BOOL)muteVideo:(NSInteger)callId on:(BOOL)on;
		[Export("muteVideo:on:")]
		bool MuteVideo(nint callId, bool on);

		// -(BOOL)switchCameraToFront:(NSInteger)callId on:(BOOL)on;
		[Export("switchCameraToFront:on:")]
		bool SwitchCameraToFront(nint callId, bool on);

		//  (void)setCall:(NSInteger)callId remoteView:(UIImageView * _Nullable)view;
		[Export("setCall:remoteView:")]
		void SetCallRemoteView(nint callId, [NullAllowed] UIImageView view);

		//  (void)setCall:(NSInteger)callId localView:(UIImageView * _Nullable)view;
		[Export("setCall:localView:")]
		void SetCallLocalView(nint callId, [NullAllowed] UIImageView view);

		// +(NSString * _Nonnull)sipUriUsername:(NSString * _Nullable)uri;
		[Static]
		[Export("sipUriUsername:")]
		[NullAllowed]
		string SipUriUsername([NullAllowed] string uri);

		// +(NSString * _Nonnull)sipUriDomain:(NSString * _Nullable)uri;
		[Static]
		[Export("sipUriDomain:")]
		[NullAllowed]
		string SipUriDomain([NullAllowed] string uri);

		// +(NSString * _Nonnull)sipUriDisplayName:(NSString * _Nullable)uri;
		[Static]
		[Export("sipUriDisplayName:")]
		[NullAllowed]
		string SipUriDisplayName([NullAllowed] string uri);

		// -(BOOL)startRecordingFor:(NSInteger)callId filePath:(NSString * _Nonnull)name;
		[Export("startRecordingFor:filePath:")]
		bool StartRecordingFor(nint callId, string name);

		// -(BOOL)stopRecording;
		[Export("stopRecording")]
		bool StopRecording();

		// -(AbtoPhoneMediaQuality * _Nullable)readCallMediaQuality:(NSInteger)callId isVideo:(BOOL)video;
		[Export("readCallMediaQuality:isVideo:")]
		[NullAllowed]
		AbtoPhoneMediaQuality ReadCallMediaQuality(nint callId, bool video);

		// -(BOOL)isZrtpSecured:(NSInteger)callId;
		[Export("isZrtpSecured:")]
		bool IsZrtpSecured(nint callId);

		// -(void)setSasCall:(NSInteger)callId validity:(BOOL)valid;
		[Export("setSasCall:validity:")]
		void SetSasCall(nint callId, bool valid);

		// - (void)deactivateAudio;
		[Export("deactivateAudio")]
		void DeactivateAudio();

		// - (BOOL)activateAudio;
		[Export("activateAudio")]
		bool ActivateAudio();

		// +(NSDictionary * _Nonnull)mwiMessageClasses:(NSString * _Nullable)text;
		[Static]
		[Export("mwiMessageClasses:")]
		NSDictionary MwiMessageClasses([NullAllowed] string text);

		// - (void)setRecordProcessing:(void (^_Nullable)(void * _Nullable pointer, NSInteger samplesPerFrame))block;
		[Export("setRecordProcessing:")]
		void SetRecordProcessing([NullAllowed] Action<IntPtr, nint> processingHandler);
	}
}

