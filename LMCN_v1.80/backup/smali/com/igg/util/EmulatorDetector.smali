.class public final Lcom/igg/util/EmulatorDetector;
.super Ljava/lang/Object;
.source "EmulatorDetector.java"


# annotations
.annotation build Landroid/annotation/TargetApi;
    value = 0xe
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/util/EmulatorDetector$OnEmulatorDetectorListener;
    }
.end annotation


# static fields
.field private static final ANDY_FILES:[Ljava/lang/String;

.field private static final DEVICE_IDS:[Ljava/lang/String;

.field private static final GENY_FILES:[Ljava/lang/String;

.field private static final IMSI_IDS:[Ljava/lang/String;

.field private static final IP:Ljava/lang/String; = "10.0.2.15"

.field private static final MIN_PROPERTIES_THRESHOLD:I = 0x5

.field private static final PHONE_NUMBERS:[Ljava/lang/String;

.field private static final PIPES:[Ljava/lang/String;

.field private static final PROPERTIES:[Lcom/igg/util/Property;

.field private static final QEMU_DRIVERS:[Ljava/lang/String;

.field private static final X86_FILES:[Ljava/lang/String;

.field private static mContext:Landroid/content/Context;

.field private static mEmulatorDetector:Lcom/igg/util/EmulatorDetector;


# instance fields
.field private isDebug:Z

.field private isTelephony:Z

.field private mListPackageName:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 8

    .prologue
    const/4 v7, 0x3

    const/4 v6, 0x2

    const/4 v5, 0x0

    const/4 v4, 0x1

    const/4 v3, 0x0

    .line 48
    const/16 v0, 0x10

    new-array v0, v0, [Ljava/lang/String;

    const-string v1, "15555215554"

    aput-object v1, v0, v3

    const-string v1, "15555215556"

    aput-object v1, v0, v4

    const-string v1, "15555215558"

    aput-object v1, v0, v6

    const-string v1, "15555215560"

    aput-object v1, v0, v7

    const/4 v1, 0x4

    const-string v2, "15555215562"

    aput-object v2, v0, v1

    const/4 v1, 0x5

    const-string v2, "15555215564"

    aput-object v2, v0, v1

    const/4 v1, 0x6

    const-string v2, "15555215566"

    aput-object v2, v0, v1

    const/4 v1, 0x7

    const-string v2, "15555215568"

    aput-object v2, v0, v1

    const/16 v1, 0x8

    const-string v2, "15555215570"

    aput-object v2, v0, v1

    const/16 v1, 0x9

    const-string v2, "15555215572"

    aput-object v2, v0, v1

    const/16 v1, 0xa

    const-string v2, "15555215574"

    aput-object v2, v0, v1

    const/16 v1, 0xb

    const-string v2, "15555215576"

    aput-object v2, v0, v1

    const/16 v1, 0xc

    const-string v2, "15555215578"

    aput-object v2, v0, v1

    const/16 v1, 0xd

    const-string v2, "15555215580"

    aput-object v2, v0, v1

    const/16 v1, 0xe

    const-string v2, "15555215582"

    aput-object v2, v0, v1

    const/16 v1, 0xf

    const-string v2, "15555215584"

    aput-object v2, v0, v1

    sput-object v0, Lcom/igg/util/EmulatorDetector;->PHONE_NUMBERS:[Ljava/lang/String;

    .line 54
    new-array v0, v7, [Ljava/lang/String;

    const-string v1, "000000000000000"

    aput-object v1, v0, v3

    const-string v1, "e21833235b6eef10"

    aput-object v1, v0, v4

    const-string v1, "012345678912345"

    aput-object v1, v0, v6

    sput-object v0, Lcom/igg/util/EmulatorDetector;->DEVICE_IDS:[Ljava/lang/String;

    .line 60
    new-array v0, v4, [Ljava/lang/String;

    const-string v1, "310260000000000"

    aput-object v1, v0, v3

    sput-object v0, Lcom/igg/util/EmulatorDetector;->IMSI_IDS:[Ljava/lang/String;

    .line 64
    new-array v0, v6, [Ljava/lang/String;

    const-string v1, "/dev/socket/genyd"

    aput-object v1, v0, v3

    const-string v1, "/dev/socket/baseband_genyd"

    aput-object v1, v0, v4

    sput-object v0, Lcom/igg/util/EmulatorDetector;->GENY_FILES:[Ljava/lang/String;

    .line 69
    new-array v0, v4, [Ljava/lang/String;

    const-string v1, "goldfish"

    aput-object v1, v0, v3

    sput-object v0, Lcom/igg/util/EmulatorDetector;->QEMU_DRIVERS:[Ljava/lang/String;

    .line 71
    new-array v0, v6, [Ljava/lang/String;

    const-string v1, "/dev/socket/qemud"

    aput-object v1, v0, v3

    const-string v1, "/dev/qemu_pipe"

    aput-object v1, v0, v4

    sput-object v0, Lcom/igg/util/EmulatorDetector;->PIPES:[Ljava/lang/String;

    .line 76
    const/16 v0, 0x8

    new-array v0, v0, [Ljava/lang/String;

    const-string v1, "ueventd.android_x86.rc"

    aput-object v1, v0, v3

    const-string v1, "x86.prop"

    aput-object v1, v0, v4

    const-string v1, "ueventd.ttVM_x86.rc"

    aput-object v1, v0, v6

    const-string v1, "init.ttVM_x86.rc"

    aput-object v1, v0, v7

    const/4 v1, 0x4

    const-string v2, "fstab.ttVM_x86"

    aput-object v2, v0, v1

    const/4 v1, 0x5

    const-string v2, "fstab.vbox86"

    aput-object v2, v0, v1

    const/4 v1, 0x6

    const-string v2, "init.vbox86.rc"

    aput-object v2, v0, v1

    const/4 v1, 0x7

    const-string v2, "ueventd.vbox86.rc"

    aput-object v2, v0, v1

    sput-object v0, Lcom/igg/util/EmulatorDetector;->X86_FILES:[Ljava/lang/String;

    .line 87
    new-array v0, v6, [Ljava/lang/String;

    const-string v1, "fstab.andy"

    aput-object v1, v0, v3

    const-string v1, "ueventd.andy.rc"

    aput-object v1, v0, v4

    sput-object v0, Lcom/igg/util/EmulatorDetector;->ANDY_FILES:[Ljava/lang/String;

    .line 92
    const/16 v0, 0xf

    new-array v0, v0, [Lcom/igg/util/Property;

    new-instance v1, Lcom/igg/util/Property;

    const-string v2, "init.svc.qemud"

    invoke-direct {v1, v2, v5}, Lcom/igg/util/Property;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    aput-object v1, v0, v3

    new-instance v1, Lcom/igg/util/Property;

    const-string v2, "init.svc.qemu-props"

    invoke-direct {v1, v2, v5}, Lcom/igg/util/Property;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    aput-object v1, v0, v4

    new-instance v1, Lcom/igg/util/Property;

    const-string v2, "qemu.hw.mainkeys"

    invoke-direct {v1, v2, v5}, Lcom/igg/util/Property;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    aput-object v1, v0, v6

    new-instance v1, Lcom/igg/util/Property;

    const-string v2, "qemu.sf.fake_camera"

    invoke-direct {v1, v2, v5}, Lcom/igg/util/Property;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    aput-object v1, v0, v7

    const/4 v1, 0x4

    new-instance v2, Lcom/igg/util/Property;

    const-string v3, "qemu.sf.lcd_density"

    invoke-direct {v2, v3, v5}, Lcom/igg/util/Property;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    aput-object v2, v0, v1

    const/4 v1, 0x5

    new-instance v2, Lcom/igg/util/Property;

    const-string v3, "ro.bootloader"

    const-string v4, "unknown"

    invoke-direct {v2, v3, v4}, Lcom/igg/util/Property;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    aput-object v2, v0, v1

    const/4 v1, 0x6

    new-instance v2, Lcom/igg/util/Property;

    const-string v3, "ro.bootmode"

    const-string v4, "unknown"

    invoke-direct {v2, v3, v4}, Lcom/igg/util/Property;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    aput-object v2, v0, v1

    const/4 v1, 0x7

    new-instance v2, Lcom/igg/util/Property;

    const-string v3, "ro.hardware"

    const-string v4, "goldfish"

    invoke-direct {v2, v3, v4}, Lcom/igg/util/Property;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    aput-object v2, v0, v1

    const/16 v1, 0x8

    new-instance v2, Lcom/igg/util/Property;

    const-string v3, "ro.kernel.android.qemud"

    invoke-direct {v2, v3, v5}, Lcom/igg/util/Property;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    aput-object v2, v0, v1

    const/16 v1, 0x9

    new-instance v2, Lcom/igg/util/Property;

    const-string v3, "ro.kernel.qemu.gles"

    invoke-direct {v2, v3, v5}, Lcom/igg/util/Property;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    aput-object v2, v0, v1

    const/16 v1, 0xa

    new-instance v2, Lcom/igg/util/Property;

    const-string v3, "ro.kernel.qemu"

    const-string v4, "1"

    invoke-direct {v2, v3, v4}, Lcom/igg/util/Property;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    aput-object v2, v0, v1

    const/16 v1, 0xb

    new-instance v2, Lcom/igg/util/Property;

    const-string v3, "ro.product.device"

    const-string v4, "generic"

    invoke-direct {v2, v3, v4}, Lcom/igg/util/Property;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    aput-object v2, v0, v1

    const/16 v1, 0xc

    new-instance v2, Lcom/igg/util/Property;

    const-string v3, "ro.product.model"

    const-string v4, "sdk"

    invoke-direct {v2, v3, v4}, Lcom/igg/util/Property;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    aput-object v2, v0, v1

    const/16 v1, 0xd

    new-instance v2, Lcom/igg/util/Property;

    const-string v3, "ro.product.name"

    const-string v4, "sdk"

    invoke-direct {v2, v3, v4}, Lcom/igg/util/Property;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    aput-object v2, v0, v1

    const/16 v1, 0xe

    new-instance v2, Lcom/igg/util/Property;

    const-string v3, "ro.serialno"

    invoke-direct {v2, v3, v5}, Lcom/igg/util/Property;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    aput-object v2, v0, v1

    sput-object v0, Lcom/igg/util/EmulatorDetector;->PROPERTIES:[Lcom/igg/util/Property;

    return-void
.end method

.method public constructor <init>(Landroid/content/Context;)V
    .locals 2
    .param p1, "pContext"    # Landroid/content/Context;

    .prologue
    const/4 v0, 0x0

    .line 127
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 115
    iput-boolean v0, p0, Lcom/igg/util/EmulatorDetector;->isDebug:Z

    .line 116
    iput-boolean v0, p0, Lcom/igg/util/EmulatorDetector;->isTelephony:Z

    .line 117
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/igg/util/EmulatorDetector;->mListPackageName:Ljava/util/List;

    .line 128
    sput-object p1, Lcom/igg/util/EmulatorDetector;->mContext:Landroid/content/Context;

    .line 129
    iget-object v0, p0, Lcom/igg/util/EmulatorDetector;->mListPackageName:Ljava/util/List;

    const-string v1, "com.google.android.launcher.layouts.genymotion"

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 130
    iget-object v0, p0, Lcom/igg/util/EmulatorDetector;->mListPackageName:Ljava/util/List;

    const-string v1, "com.bluestacks"

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 131
    iget-object v0, p0, Lcom/igg/util/EmulatorDetector;->mListPackageName:Ljava/util/List;

    const-string v1, "com.bignox.app"

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 132
    return-void
.end method

.method static synthetic access$000(Lcom/igg/util/EmulatorDetector;Ljava/lang/String;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/util/EmulatorDetector;
    .param p1, "x1"    # Ljava/lang/String;

    .prologue
    .line 43
    invoke-direct {p0, p1}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    return-void
.end method

.method private checkAdvanced()Z
    .locals 2

    .prologue
    .line 232
    invoke-direct {p0}, Lcom/igg/util/EmulatorDetector;->checkTelephony()Z

    move-result v1

    if-nez v1, :cond_0

    .line 233
    invoke-direct {p0}, Lcom/igg/util/EmulatorDetector;->checkGenyFiles()Z

    move-result v1

    if-nez v1, :cond_0

    .line 234
    invoke-direct {p0}, Lcom/igg/util/EmulatorDetector;->checkAndyFiles()Z

    move-result v1

    if-nez v1, :cond_0

    .line 235
    invoke-direct {p0}, Lcom/igg/util/EmulatorDetector;->checkQEmuDrivers()Z

    move-result v1

    if-nez v1, :cond_0

    .line 236
    invoke-direct {p0}, Lcom/igg/util/EmulatorDetector;->checkPipes()Z

    move-result v1

    if-nez v1, :cond_0

    .line 237
    invoke-direct {p0}, Lcom/igg/util/EmulatorDetector;->checkIp()Z

    move-result v1

    if-nez v1, :cond_0

    .line 238
    invoke-direct {p0}, Lcom/igg/util/EmulatorDetector;->checkQEmuProps()Z

    move-result v1

    if-eqz v1, :cond_1

    invoke-direct {p0}, Lcom/igg/util/EmulatorDetector;->checkX86Files()Z

    move-result v1

    if-eqz v1, :cond_1

    :cond_0
    const/4 v0, 0x1

    .line 239
    .local v0, "result":Z
    :goto_0
    return v0

    .line 238
    .end local v0    # "result":Z
    :cond_1
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private checkAndyFiles()Z
    .locals 7

    .prologue
    const/4 v2, 0x0

    .line 383
    sget-object v4, Lcom/igg/util/EmulatorDetector;->ANDY_FILES:[Ljava/lang/String;

    array-length v5, v4

    move v3, v2

    :goto_0
    if-ge v3, v5, :cond_0

    aget-object v0, v4, v3

    .line 384
    .local v0, "pipe":Ljava/lang/String;
    new-instance v1, Ljava/io/File;

    invoke-direct {v1, v0}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    .line 385
    .local v1, "qemu_file":Ljava/io/File;
    invoke-virtual {v1}, Ljava/io/File;->exists()Z

    move-result v6

    if-eqz v6, :cond_1

    .line 386
    const-string v2, "Check Andy is detected"

    invoke-direct {p0, v2}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 387
    const/4 v2, 0x1

    .line 390
    .end local v0    # "pipe":Ljava/lang/String;
    .end local v1    # "qemu_file":Ljava/io/File;
    :cond_0
    return v2

    .line 383
    .restart local v0    # "pipe":Ljava/lang/String;
    .restart local v1    # "qemu_file":Ljava/io/File;
    :cond_1
    add-int/lit8 v3, v3, 0x1

    goto :goto_0
.end method

.method private checkBasic()Z
    .locals 5

    .prologue
    const/4 v2, 0x0

    const/4 v1, 0x1

    .line 206
    sget-object v3, Landroid/os/Build;->FINGERPRINT:Ljava/lang/String;

    const-string v4, "generic"

    invoke-virtual {v3, v4}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->MODEL:Ljava/lang/String;

    const-string v4, "google_sdk"

    .line 207
    invoke-virtual {v3, v4}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->MODEL:Ljava/lang/String;

    .line 208
    invoke-virtual {v3}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v3

    const-string v4, "droid4x"

    invoke-virtual {v3, v4}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->MODEL:Ljava/lang/String;

    const-string v4, "Emulator"

    .line 209
    invoke-virtual {v3, v4}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->MODEL:Ljava/lang/String;

    const-string v4, "Android SDK built for x86"

    .line 210
    invoke-virtual {v3, v4}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->MANUFACTURER:Ljava/lang/String;

    const-string v4, "Genymotion"

    .line 211
    invoke-virtual {v3, v4}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->HARDWARE:Ljava/lang/String;

    const-string v4, "goldfish"

    .line 212
    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->HARDWARE:Ljava/lang/String;

    const-string v4, "vbox86"

    .line 213
    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->PRODUCT:Ljava/lang/String;

    const-string v4, "sdk"

    .line 214
    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->PRODUCT:Ljava/lang/String;

    const-string v4, "google_sdk"

    .line 215
    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->PRODUCT:Ljava/lang/String;

    const-string v4, "sdk_x86"

    .line 216
    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->PRODUCT:Ljava/lang/String;

    const-string v4, "vbox86p"

    .line 217
    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->BOARD:Ljava/lang/String;

    .line 218
    invoke-virtual {v3}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v3

    const-string v4, "nox"

    invoke-virtual {v3, v4}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->BOOTLOADER:Ljava/lang/String;

    .line 219
    invoke-virtual {v3}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v3

    const-string v4, "nox"

    invoke-virtual {v3, v4}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->HARDWARE:Ljava/lang/String;

    .line 220
    invoke-virtual {v3}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v3

    const-string v4, "nox"

    invoke-virtual {v3, v4}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->PRODUCT:Ljava/lang/String;

    .line 221
    invoke-virtual {v3}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v3

    const-string v4, "nox"

    invoke-virtual {v3, v4}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v3

    if-nez v3, :cond_0

    sget-object v3, Landroid/os/Build;->SERIAL:Ljava/lang/String;

    .line 222
    invoke-virtual {v3}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v3

    const-string v4, "nox"

    invoke-virtual {v3, v4}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v3

    if-eqz v3, :cond_2

    :cond_0
    move v0, v1

    .line 224
    .local v0, "result":Z
    :goto_0
    if-eqz v0, :cond_3

    .line 228
    :cond_1
    :goto_1
    return v1

    .end local v0    # "result":Z
    :cond_2
    move v0, v2

    .line 222
    goto :goto_0

    .line 225
    .restart local v0    # "result":Z
    :cond_3
    sget-object v3, Landroid/os/Build;->BRAND:Ljava/lang/String;

    const-string v4, "generic"

    invoke-virtual {v3, v4}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_4

    sget-object v3, Landroid/os/Build;->DEVICE:Ljava/lang/String;

    const-string v4, "generic"

    invoke-virtual {v3, v4}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_4

    move v2, v1

    :cond_4
    or-int/2addr v0, v2

    .line 226
    if-nez v0, :cond_1

    .line 227
    const-string v1, "google_sdk"

    sget-object v2, Landroid/os/Build;->PRODUCT:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    or-int/2addr v0, v1

    move v1, v0

    .line 228
    goto :goto_1
.end method

.method private checkDeviceId()Z
    .locals 8

    .prologue
    const/4 v3, 0x0

    .line 285
    sget-object v4, Lcom/igg/util/EmulatorDetector;->mContext:Landroid/content/Context;

    const-string v5, "phone"

    .line 286
    invoke-virtual {v4, v5}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroid/telephony/TelephonyManager;

    .line 288
    .local v2, "telephonyManager":Landroid/telephony/TelephonyManager;
    invoke-virtual {v2}, Landroid/telephony/TelephonyManager;->getDeviceId()Ljava/lang/String;

    move-result-object v0

    .line 290
    .local v0, "deviceId":Ljava/lang/String;
    sget-object v5, Lcom/igg/util/EmulatorDetector;->DEVICE_IDS:[Ljava/lang/String;

    array-length v6, v5

    move v4, v3

    :goto_0
    if-ge v4, v6, :cond_0

    aget-object v1, v5, v4

    .line 291
    .local v1, "known_deviceId":Ljava/lang/String;
    invoke-virtual {v1, v0}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_1

    .line 292
    const-string v3, "Check device id is detected"

    invoke-direct {p0, v3}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 293
    const/4 v3, 0x1

    .line 297
    .end local v1    # "known_deviceId":Ljava/lang/String;
    :cond_0
    return v3

    .line 290
    .restart local v1    # "known_deviceId":Ljava/lang/String;
    :cond_1
    add-int/lit8 v4, v4, 0x1

    goto :goto_0
.end method

.method private checkGenyFiles()Z
    .locals 7

    .prologue
    const/4 v2, 0x0

    .line 325
    sget-object v4, Lcom/igg/util/EmulatorDetector;->GENY_FILES:[Ljava/lang/String;

    array-length v5, v4

    move v3, v2

    :goto_0
    if-ge v3, v5, :cond_0

    aget-object v0, v4, v3

    .line 326
    .local v0, "file":Ljava/lang/String;
    new-instance v1, Ljava/io/File;

    invoke-direct {v1, v0}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    .line 327
    .local v1, "geny_file":Ljava/io/File;
    invoke-virtual {v1}, Ljava/io/File;->exists()Z

    move-result v6

    if-eqz v6, :cond_1

    .line 328
    const-string v2, "Check genymotion is detected"

    invoke-direct {p0, v2}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 329
    const/4 v2, 0x1

    .line 332
    .end local v0    # "file":Ljava/lang/String;
    .end local v1    # "geny_file":Ljava/io/File;
    :cond_0
    return v2

    .line 325
    .restart local v0    # "file":Ljava/lang/String;
    .restart local v1    # "geny_file":Ljava/io/File;
    :cond_1
    add-int/lit8 v3, v3, 0x1

    goto :goto_0
.end method

.method private checkImsi()Z
    .locals 8

    .prologue
    const/4 v3, 0x0

    .line 301
    sget-object v4, Lcom/igg/util/EmulatorDetector;->mContext:Landroid/content/Context;

    const-string v5, "phone"

    .line 302
    invoke-virtual {v4, v5}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroid/telephony/TelephonyManager;

    .line 303
    .local v2, "telephonyManager":Landroid/telephony/TelephonyManager;
    invoke-virtual {v2}, Landroid/telephony/TelephonyManager;->getSubscriberId()Ljava/lang/String;

    move-result-object v0

    .line 305
    .local v0, "imsi":Ljava/lang/String;
    sget-object v5, Lcom/igg/util/EmulatorDetector;->IMSI_IDS:[Ljava/lang/String;

    array-length v6, v5

    move v4, v3

    :goto_0
    if-ge v4, v6, :cond_0

    aget-object v1, v5, v4

    .line 306
    .local v1, "known_imsi":Ljava/lang/String;
    invoke-virtual {v1, v0}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_1

    .line 307
    const-string v3, "Check imsi is detected"

    invoke-direct {p0, v3}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 308
    const/4 v3, 0x1

    .line 311
    .end local v1    # "known_imsi":Ljava/lang/String;
    :cond_0
    return v3

    .line 305
    .restart local v1    # "known_imsi":Ljava/lang/String;
    :cond_1
    add-int/lit8 v4, v4, 0x1

    goto :goto_0
.end method

.method private checkIp()Z
    .locals 14

    .prologue
    const/4 v13, 0x1

    const/4 v10, 0x0

    .line 416
    const/4 v4, 0x0

    .line 417
    .local v4, "ipDetected":Z
    sget-object v11, Lcom/igg/util/EmulatorDetector;->mContext:Landroid/content/Context;

    const-string v12, "android.permission.INTERNET"

    invoke-static {v11, v12}, Landroid/support/v4/content/ContextCompat;->checkSelfPermission(Landroid/content/Context;Ljava/lang/String;)I

    move-result v11

    if-nez v11, :cond_1

    .line 419
    new-array v0, v13, [Ljava/lang/String;

    const-string v11, "/system/bin/netcfg"

    aput-object v11, v0, v10

    .line 420
    .local v0, "args":[Ljava/lang/String;
    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    .line 422
    .local v9, "stringBuilder":Ljava/lang/StringBuilder;
    :try_start_0
    new-instance v2, Ljava/lang/ProcessBuilder;

    invoke-direct {v2, v0}, Ljava/lang/ProcessBuilder;-><init>([Ljava/lang/String;)V

    .line 423
    .local v2, "builder":Ljava/lang/ProcessBuilder;
    new-instance v11, Ljava/io/File;

    const-string v12, "/system/bin/"

    invoke-direct {v11, v12}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    invoke-virtual {v2, v11}, Ljava/lang/ProcessBuilder;->directory(Ljava/io/File;)Ljava/lang/ProcessBuilder;

    .line 424
    const/4 v11, 0x1

    invoke-virtual {v2, v11}, Ljava/lang/ProcessBuilder;->redirectErrorStream(Z)Ljava/lang/ProcessBuilder;

    .line 425
    invoke-virtual {v2}, Ljava/lang/ProcessBuilder;->start()Ljava/lang/Process;

    move-result-object v7

    .line 426
    .local v7, "process":Ljava/lang/Process;
    invoke-virtual {v7}, Ljava/lang/Process;->getInputStream()Ljava/io/InputStream;

    move-result-object v3

    .line 427
    .local v3, "in":Ljava/io/InputStream;
    const/16 v11, 0x400

    new-array v8, v11, [B

    .line 428
    .local v8, "re":[B
    :goto_0
    invoke-virtual {v3, v8}, Ljava/io/InputStream;->read([B)I

    move-result v11

    const/4 v12, -0x1

    if-eq v11, v12, :cond_2

    .line 429
    new-instance v11, Ljava/lang/String;

    invoke-direct {v11, v8}, Ljava/lang/String;-><init>([B)V

    invoke-virtual {v9, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 433
    .end local v2    # "builder":Ljava/lang/ProcessBuilder;
    .end local v3    # "in":Ljava/io/InputStream;
    .end local v7    # "process":Ljava/lang/Process;
    .end local v8    # "re":[B
    :catch_0
    move-exception v11

    .line 437
    :goto_1
    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    .line 438
    .local v6, "netData":Ljava/lang/String;
    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "netcfg data -> "

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-direct {p0, v11}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 440
    invoke-static {v6}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v11

    if-nez v11, :cond_1

    .line 441
    const-string v11, "\n"

    invoke-virtual {v6, v11}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v1

    .line 444
    .local v1, "array":[Ljava/lang/String;
    array-length v11, v1

    :goto_2
    if-ge v10, v11, :cond_1

    aget-object v5, v1, v10

    .line 445
    .local v5, "lan":Ljava/lang/String;
    const-string v12, "wlan0"

    invoke-virtual {v5, v12}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v12

    if-nez v12, :cond_0

    const-string v12, "tunl0"

    invoke-virtual {v5, v12}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v12

    if-nez v12, :cond_0

    const-string v12, "eth0"

    invoke-virtual {v5, v12}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v12

    if-eqz v12, :cond_3

    :cond_0
    const-string v12, "10.0.2.15"

    .line 446
    invoke-virtual {v5, v12}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v12

    if-eqz v12, :cond_3

    .line 447
    const/4 v4, 0x1

    .line 448
    const-string v10, "Check IP is detected"

    invoke-direct {p0, v10}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 455
    .end local v0    # "args":[Ljava/lang/String;
    .end local v1    # "array":[Ljava/lang/String;
    .end local v5    # "lan":Ljava/lang/String;
    .end local v6    # "netData":Ljava/lang/String;
    .end local v9    # "stringBuilder":Ljava/lang/StringBuilder;
    :cond_1
    return v4

    .line 431
    .restart local v0    # "args":[Ljava/lang/String;
    .restart local v2    # "builder":Ljava/lang/ProcessBuilder;
    .restart local v3    # "in":Ljava/io/InputStream;
    .restart local v7    # "process":Ljava/lang/Process;
    .restart local v8    # "re":[B
    .restart local v9    # "stringBuilder":Ljava/lang/StringBuilder;
    :cond_2
    :try_start_1
    invoke-virtual {v3}, Ljava/io/InputStream;->close()V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_1

    .line 444
    .end local v2    # "builder":Ljava/lang/ProcessBuilder;
    .end local v3    # "in":Ljava/io/InputStream;
    .end local v7    # "process":Ljava/lang/Process;
    .end local v8    # "re":[B
    .restart local v1    # "array":[Ljava/lang/String;
    .restart local v5    # "lan":Ljava/lang/String;
    .restart local v6    # "netData":Ljava/lang/String;
    :cond_3
    add-int/lit8 v10, v10, 0x1

    goto :goto_2
.end method

.method private checkOperatorNameAndroid()Z
    .locals 3

    .prologue
    .line 315
    sget-object v1, Lcom/igg/util/EmulatorDetector;->mContext:Landroid/content/Context;

    const-string v2, "phone"

    .line 316
    invoke-virtual {v1, v2}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Landroid/telephony/TelephonyManager;

    invoke-virtual {v1}, Landroid/telephony/TelephonyManager;->getNetworkOperatorName()Ljava/lang/String;

    move-result-object v0

    .line 317
    .local v0, "operatorName":Ljava/lang/String;
    const-string v1, "android"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 318
    const-string v1, "Check operator name android is detected"

    invoke-direct {p0, v1}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 319
    const/4 v1, 0x1

    .line 321
    :goto_0
    return v1

    :cond_0
    const/4 v1, 0x0

    goto :goto_0
.end method

.method private checkPackageName()Z
    .locals 7

    .prologue
    .line 243
    sget-object v5, Lcom/igg/util/EmulatorDetector;->mContext:Landroid/content/Context;

    invoke-virtual {v5}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v2

    .line 244
    .local v2, "packageManager":Landroid/content/pm/PackageManager;
    const/16 v5, 0x80

    .line 245
    invoke-virtual {v2, v5}, Landroid/content/pm/PackageManager;->getInstalledApplications(I)Ljava/util/List;

    move-result-object v4

    .line 246
    .local v4, "packages":Ljava/util/List;, "Ljava/util/List<Landroid/content/pm/ApplicationInfo;>;"
    invoke-interface {v4}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v5

    :cond_0
    invoke-interface {v5}, Ljava/util/Iterator;->hasNext()Z

    move-result v6

    if-eqz v6, :cond_1

    invoke-interface {v5}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Landroid/content/pm/ApplicationInfo;

    .line 247
    .local v1, "packageInfo":Landroid/content/pm/ApplicationInfo;
    iget-object v3, v1, Landroid/content/pm/ApplicationInfo;->packageName:Ljava/lang/String;

    .line 248
    .local v3, "packageName":Ljava/lang/String;
    iget-object v6, p0, Lcom/igg/util/EmulatorDetector;->mListPackageName:Ljava/util/List;

    invoke-interface {v6, v3}, Ljava/util/List;->contains(Ljava/lang/Object;)Z

    move-result v0

    .line 249
    .local v0, "isEmulator":Z
    if-eqz v0, :cond_0

    .line 250
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "Detected "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-direct {p0, v5}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 251
    const/4 v5, 0x1

    .line 254
    .end local v0    # "isEmulator":Z
    .end local v1    # "packageInfo":Landroid/content/pm/ApplicationInfo;
    .end local v3    # "packageName":Ljava/lang/String;
    :goto_0
    return v5

    :cond_1
    const/4 v5, 0x0

    goto :goto_0
.end method

.method private checkPhoneNumber()Z
    .locals 8

    .prologue
    const/4 v3, 0x0

    .line 269
    sget-object v4, Lcom/igg/util/EmulatorDetector;->mContext:Landroid/content/Context;

    const-string v5, "phone"

    .line 270
    invoke-virtual {v4, v5}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroid/telephony/TelephonyManager;

    .line 272
    .local v2, "telephonyManager":Landroid/telephony/TelephonyManager;
    invoke-virtual {v2}, Landroid/telephony/TelephonyManager;->getLine1Number()Ljava/lang/String;

    move-result-object v1

    .line 274
    .local v1, "phoneNumber":Ljava/lang/String;
    sget-object v5, Lcom/igg/util/EmulatorDetector;->PHONE_NUMBERS:[Ljava/lang/String;

    array-length v6, v5

    move v4, v3

    :goto_0
    if-ge v4, v6, :cond_0

    aget-object v0, v5, v4

    .line 275
    .local v0, "number":Ljava/lang/String;
    invoke-virtual {v0, v1}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_1

    .line 276
    const-string v3, " check phone number is detected"

    invoke-direct {p0, v3}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 277
    const/4 v3, 0x1

    .line 281
    .end local v0    # "number":Ljava/lang/String;
    :cond_0
    return v3

    .line 274
    .restart local v0    # "number":Ljava/lang/String;
    :cond_1
    add-int/lit8 v4, v4, 0x1

    goto :goto_0
.end method

.method private checkPipes()Z
    .locals 7

    .prologue
    const/4 v2, 0x0

    .line 361
    sget-object v4, Lcom/igg/util/EmulatorDetector;->PIPES:[Ljava/lang/String;

    array-length v5, v4

    move v3, v2

    :goto_0
    if-ge v3, v5, :cond_0

    aget-object v0, v4, v3

    .line 362
    .local v0, "pipe":Ljava/lang/String;
    new-instance v1, Ljava/io/File;

    invoke-direct {v1, v0}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    .line 363
    .local v1, "qemu_socket":Ljava/io/File;
    invoke-virtual {v1}, Ljava/io/File;->exists()Z

    move-result v6

    if-eqz v6, :cond_1

    .line 364
    const-string v2, "Check pipes is detected"

    invoke-direct {p0, v2}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 365
    const/4 v2, 0x1

    .line 368
    .end local v0    # "pipe":Ljava/lang/String;
    .end local v1    # "qemu_socket":Ljava/io/File;
    :cond_0
    return v2

    .line 361
    .restart local v0    # "pipe":Ljava/lang/String;
    .restart local v1    # "qemu_socket":Ljava/io/File;
    :cond_1
    add-int/lit8 v3, v3, 0x1

    goto :goto_0
.end method

.method private checkQEmuDrivers()Z
    .locals 14

    .prologue
    .line 336
    const/4 v6, 0x2

    new-array v8, v6, [Ljava/io/File;

    const/4 v6, 0x0

    new-instance v7, Ljava/io/File;

    const-string v9, "/proc/tty/drivers"

    invoke-direct {v7, v9}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    aput-object v7, v8, v6

    const/4 v6, 0x1

    new-instance v7, Ljava/io/File;

    const-string v9, "/proc/cpuinfo"

    invoke-direct {v7, v9}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    aput-object v7, v8, v6

    array-length v9, v8

    const/4 v6, 0x0

    move v7, v6

    :goto_0
    if-ge v7, v9, :cond_2

    aget-object v2, v8, v7

    .line 337
    .local v2, "drivers_file":Ljava/io/File;
    invoke-virtual {v2}, Ljava/io/File;->exists()Z

    move-result v6

    if-eqz v6, :cond_1

    invoke-virtual {v2}, Ljava/io/File;->canRead()Z

    move-result v6

    if-eqz v6, :cond_1

    .line 338
    const/16 v6, 0x400

    new-array v0, v6, [B

    .line 340
    .local v0, "data":[B
    :try_start_0
    new-instance v4, Ljava/io/FileInputStream;

    invoke-direct {v4, v2}, Ljava/io/FileInputStream;-><init>(Ljava/io/File;)V

    .line 341
    .local v4, "is":Ljava/io/InputStream;
    invoke-virtual {v4, v0}, Ljava/io/InputStream;->read([B)I

    .line 342
    invoke-virtual {v4}, Ljava/io/InputStream;->close()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 347
    .end local v4    # "is":Ljava/io/InputStream;
    :goto_1
    new-instance v1, Ljava/lang/String;

    invoke-direct {v1, v0}, Ljava/lang/String;-><init>([B)V

    .line 348
    .local v1, "driver_data":Ljava/lang/String;
    sget-object v10, Lcom/igg/util/EmulatorDetector;->QEMU_DRIVERS:[Ljava/lang/String;

    array-length v11, v10

    const/4 v6, 0x0

    :goto_2
    if-ge v6, v11, :cond_1

    aget-object v5, v10, v6

    .line 349
    .local v5, "known_qemu_driver":Ljava/lang/String;
    invoke-virtual {v1, v5}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v12

    const/4 v13, -0x1

    if-eq v12, v13, :cond_0

    .line 350
    const-string v6, "Check QEmuDrivers is detected"

    invoke-direct {p0, v6}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 351
    const/4 v6, 0x1

    .line 357
    .end local v0    # "data":[B
    .end local v1    # "driver_data":Ljava/lang/String;
    .end local v2    # "drivers_file":Ljava/io/File;
    .end local v5    # "known_qemu_driver":Ljava/lang/String;
    :goto_3
    return v6

    .line 343
    .restart local v0    # "data":[B
    .restart local v2    # "drivers_file":Ljava/io/File;
    :catch_0
    move-exception v3

    .line 344
    .local v3, "exception":Ljava/lang/Exception;
    invoke-virtual {v3}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_1

    .line 348
    .end local v3    # "exception":Ljava/lang/Exception;
    .restart local v1    # "driver_data":Ljava/lang/String;
    .restart local v5    # "known_qemu_driver":Ljava/lang/String;
    :cond_0
    add-int/lit8 v6, v6, 0x1

    goto :goto_2

    .line 336
    .end local v0    # "data":[B
    .end local v1    # "driver_data":Ljava/lang/String;
    .end local v5    # "known_qemu_driver":Ljava/lang/String;
    :cond_1
    add-int/lit8 v6, v7, 0x1

    move v7, v6

    goto :goto_0

    .line 357
    .end local v2    # "drivers_file":Ljava/io/File;
    :cond_2
    const/4 v6, 0x0

    goto :goto_3
.end method

.method private checkQEmuProps()Z
    .locals 9

    .prologue
    const/4 v3, 0x0

    .line 394
    const/4 v0, 0x0

    .line 396
    .local v0, "found_props":I
    sget-object v5, Lcom/igg/util/EmulatorDetector;->PROPERTIES:[Lcom/igg/util/Property;

    array-length v6, v5

    move v4, v3

    :goto_0
    if-ge v4, v6, :cond_2

    aget-object v1, v5, v4

    .line 397
    .local v1, "property":Lcom/igg/util/Property;
    sget-object v7, Lcom/igg/util/EmulatorDetector;->mContext:Landroid/content/Context;

    iget-object v8, v1, Lcom/igg/util/Property;->name:Ljava/lang/String;

    invoke-direct {p0, v7, v8}, Lcom/igg/util/EmulatorDetector;->getProp(Landroid/content/Context;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 398
    .local v2, "property_value":Ljava/lang/String;
    iget-object v7, v1, Lcom/igg/util/Property;->seek_value:Ljava/lang/String;

    if-nez v7, :cond_0

    if-eqz v2, :cond_0

    .line 399
    add-int/lit8 v0, v0, 0x1

    .line 401
    :cond_0
    iget-object v7, v1, Lcom/igg/util/Property;->seek_value:Ljava/lang/String;

    if-eqz v7, :cond_1

    iget-object v7, v1, Lcom/igg/util/Property;->seek_value:Ljava/lang/String;

    .line 402
    invoke-virtual {v2, v7}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v7

    const/4 v8, -0x1

    if-eq v7, v8, :cond_1

    .line 403
    add-int/lit8 v0, v0, 0x1

    .line 396
    :cond_1
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    .line 408
    .end local v1    # "property":Lcom/igg/util/Property;
    .end local v2    # "property_value":Ljava/lang/String;
    :cond_2
    const/4 v4, 0x5

    if-lt v0, v4, :cond_3

    .line 409
    const-string v3, "Check QEmuProps is detected"

    invoke-direct {p0, v3}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 410
    const/4 v3, 0x1

    .line 412
    :cond_3
    return v3
.end method

.method private checkTelephony()Z
    .locals 3

    .prologue
    const/4 v0, 0x0

    .line 258
    sget-object v1, Lcom/igg/util/EmulatorDetector;->mContext:Landroid/content/Context;

    const-string v2, "android.permission.READ_PHONE_STATE"

    invoke-static {v1, v2}, Landroid/support/v4/content/ContextCompat;->checkSelfPermission(Landroid/content/Context;Ljava/lang/String;)I

    move-result v1

    if-nez v1, :cond_1

    iget-boolean v1, p0, Lcom/igg/util/EmulatorDetector;->isTelephony:Z

    if-eqz v1, :cond_1

    .line 260
    invoke-direct {p0}, Lcom/igg/util/EmulatorDetector;->checkPhoneNumber()Z

    move-result v1

    if-nez v1, :cond_0

    .line 261
    invoke-direct {p0}, Lcom/igg/util/EmulatorDetector;->checkDeviceId()Z

    move-result v1

    if-nez v1, :cond_0

    .line 262
    invoke-direct {p0}, Lcom/igg/util/EmulatorDetector;->checkImsi()Z

    move-result v1

    if-nez v1, :cond_0

    .line 263
    invoke-direct {p0}, Lcom/igg/util/EmulatorDetector;->checkOperatorNameAndroid()Z

    move-result v1

    if-eqz v1, :cond_1

    :cond_0
    const/4 v0, 0x1

    .line 265
    :cond_1
    return v0
.end method

.method private checkX86Files()Z
    .locals 7

    .prologue
    const/4 v2, 0x0

    .line 372
    sget-object v4, Lcom/igg/util/EmulatorDetector;->X86_FILES:[Ljava/lang/String;

    array-length v5, v4

    move v3, v2

    :goto_0
    if-ge v3, v5, :cond_0

    aget-object v0, v4, v3

    .line 373
    .local v0, "pipe":Ljava/lang/String;
    new-instance v1, Ljava/io/File;

    invoke-direct {v1, v0}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    .line 374
    .local v1, "qemu_file":Ljava/io/File;
    invoke-virtual {v1}, Ljava/io/File;->exists()Z

    move-result v6

    if-eqz v6, :cond_1

    .line 375
    const-string v2, "Check X86 system is detected"

    invoke-direct {p0, v2}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 376
    const/4 v2, 0x1

    .line 379
    .end local v0    # "pipe":Ljava/lang/String;
    .end local v1    # "qemu_file":Ljava/io/File;
    :cond_0
    return v2

    .line 372
    .restart local v0    # "pipe":Ljava/lang/String;
    .restart local v1    # "qemu_file":Ljava/io/File;
    :cond_1
    add-int/lit8 v3, v3, 0x1

    goto :goto_0
.end method

.method public static getDeviceInfo()Ljava/lang/String;
    .locals 2

    .prologue
    .line 483
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Build.PRODUCT: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    sget-object v1, Landroid/os/Build;->PRODUCT:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "\n"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "Build.MANUFACTURER: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    sget-object v1, Landroid/os/Build;->MANUFACTURER:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "\n"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "Build.BRAND: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    sget-object v1, Landroid/os/Build;->BRAND:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "\n"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "Build.DEVICE: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    sget-object v1, Landroid/os/Build;->DEVICE:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "\n"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "Build.MODEL: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    sget-object v1, Landroid/os/Build;->MODEL:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "\n"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "Build.HARDWARE: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    sget-object v1, Landroid/os/Build;->HARDWARE:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "\n"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "Build.FINGERPRINT: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    sget-object v1, Landroid/os/Build;->FINGERPRINT:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private getProp(Landroid/content/Context;Ljava/lang/String;)Ljava/lang/String;
    .locals 9
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "property"    # Ljava/lang/String;

    .prologue
    .line 460
    :try_start_0
    invoke-virtual {p1}, Landroid/content/Context;->getClassLoader()Ljava/lang/ClassLoader;

    move-result-object v0

    .line 461
    .local v0, "classLoader":Ljava/lang/ClassLoader;
    const-string v5, "android.os.SystemProperties"

    invoke-virtual {v0, v5}, Ljava/lang/ClassLoader;->loadClass(Ljava/lang/String;)Ljava/lang/Class;

    move-result-object v4

    .line 463
    .local v4, "systemProperties":Ljava/lang/Class;, "Ljava/lang/Class<*>;"
    const-string v5, "get"

    const/4 v6, 0x1

    new-array v6, v6, [Ljava/lang/Class;

    const/4 v7, 0x0

    const-class v8, Ljava/lang/String;

    aput-object v8, v6, v7

    invoke-virtual {v4, v5, v6}, Ljava/lang/Class;->getMethod(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v2

    .line 465
    .local v2, "get":Ljava/lang/reflect/Method;
    const/4 v5, 0x1

    new-array v3, v5, [Ljava/lang/Object;

    .line 466
    .local v3, "params":[Ljava/lang/Object;
    const/4 v5, 0x0

    new-instance v6, Ljava/lang/String;

    invoke-direct {v6, p2}, Ljava/lang/String;-><init>(Ljava/lang/String;)V

    aput-object v6, v3, v5

    .line 468
    invoke-virtual {v2, v4, v3}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 473
    .end local v0    # "classLoader":Ljava/lang/ClassLoader;
    .end local v2    # "get":Ljava/lang/reflect/Method;
    .end local v3    # "params":[Ljava/lang/Object;
    .end local v4    # "systemProperties":Ljava/lang/Class;, "Ljava/lang/Class<*>;"
    :goto_0
    return-object v5

    .line 469
    :catch_0
    move-exception v1

    .line 471
    .local v1, "e":Ljava/lang/Exception;
    invoke-virtual {v1}, Ljava/lang/Exception;->printStackTrace()V

    .line 473
    const/4 v5, 0x0

    goto :goto_0
.end method

.method private log(Ljava/lang/String;)V
    .locals 1
    .param p1, "str"    # Ljava/lang/String;

    .prologue
    .line 477
    iget-boolean v0, p0, Lcom/igg/util/EmulatorDetector;->isDebug:Z

    if-eqz v0, :cond_0

    .line 478
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 480
    :cond_0
    return-void
.end method

.method public static with(Landroid/content/Context;)Lcom/igg/util/EmulatorDetector;
    .locals 1
    .param p0, "pContext"    # Landroid/content/Context;

    .prologue
    .line 122
    sget-object v0, Lcom/igg/util/EmulatorDetector;->mEmulatorDetector:Lcom/igg/util/EmulatorDetector;

    if-nez v0, :cond_0

    .line 123
    new-instance v0, Lcom/igg/util/EmulatorDetector;

    invoke-direct {v0, p0}, Lcom/igg/util/EmulatorDetector;-><init>(Landroid/content/Context;)V

    sput-object v0, Lcom/igg/util/EmulatorDetector;->mEmulatorDetector:Lcom/igg/util/EmulatorDetector;

    .line 124
    :cond_0
    sget-object v0, Lcom/igg/util/EmulatorDetector;->mEmulatorDetector:Lcom/igg/util/EmulatorDetector;

    return-object v0
.end method


# virtual methods
.method public addPackageName(Ljava/lang/String;)Lcom/igg/util/EmulatorDetector;
    .locals 1
    .param p1, "pPackageName"    # Ljava/lang/String;

    .prologue
    .line 153
    iget-object v0, p0, Lcom/igg/util/EmulatorDetector;->mListPackageName:Ljava/util/List;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 154
    return-object p0
.end method

.method public addPackageName(Ljava/util/List;)Lcom/igg/util/EmulatorDetector;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/igg/util/EmulatorDetector;"
        }
    .end annotation

    .prologue
    .line 158
    .local p1, "pListPackageName":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    iget-object v0, p0, Lcom/igg/util/EmulatorDetector;->mListPackageName:Ljava/util/List;

    invoke-interface {v0, p1}, Ljava/util/List;->addAll(Ljava/util/Collection;)Z

    .line 159
    return-object p0
.end method

.method public detect(Lcom/igg/util/EmulatorDetector$OnEmulatorDetectorListener;)V
    .locals 2
    .param p1, "pOnEmulatorDetectorListener"    # Lcom/igg/util/EmulatorDetector$OnEmulatorDetectorListener;

    .prologue
    .line 167
    new-instance v0, Ljava/lang/Thread;

    new-instance v1, Lcom/igg/util/EmulatorDetector$1;

    invoke-direct {v1, p0, p1}, Lcom/igg/util/EmulatorDetector$1;-><init>(Lcom/igg/util/EmulatorDetector;Lcom/igg/util/EmulatorDetector$OnEmulatorDetectorListener;)V

    invoke-direct {v0, v1}, Ljava/lang/Thread;-><init>(Ljava/lang/Runnable;)V

    .line 176
    invoke-virtual {v0}, Ljava/lang/Thread;->start()V

    .line 177
    return-void
.end method

.method public detect()Z
    .locals 3

    .prologue
    .line 180
    const/4 v0, 0x0

    .line 182
    .local v0, "result":Z
    invoke-static {}, Lcom/igg/util/EmulatorDetector;->getDeviceInfo()Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v1}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 185
    if-nez v0, :cond_0

    .line 186
    invoke-direct {p0}, Lcom/igg/util/EmulatorDetector;->checkBasic()Z

    move-result v0

    .line 187
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Check basic "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v1}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 191
    :cond_0
    if-nez v0, :cond_1

    .line 192
    invoke-direct {p0}, Lcom/igg/util/EmulatorDetector;->checkAdvanced()Z

    move-result v0

    .line 193
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Check Advanced "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v1}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 197
    :cond_1
    if-nez v0, :cond_2

    .line 198
    invoke-direct {p0}, Lcom/igg/util/EmulatorDetector;->checkPackageName()Z

    move-result v0

    .line 199
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Check Package Name "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v1}, Lcom/igg/util/EmulatorDetector;->log(Ljava/lang/String;)V

    .line 202
    :cond_2
    return v0
.end method

.method public getPackageNameList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .prologue
    .line 163
    iget-object v0, p0, Lcom/igg/util/EmulatorDetector;->mListPackageName:Ljava/util/List;

    return-object v0
.end method

.method public isCheckTelephony()Z
    .locals 1

    .prologue
    .line 144
    iget-boolean v0, p0, Lcom/igg/util/EmulatorDetector;->isTelephony:Z

    return v0
.end method

.method public isDebug()Z
    .locals 1

    .prologue
    .line 140
    iget-boolean v0, p0, Lcom/igg/util/EmulatorDetector;->isDebug:Z

    return v0
.end method

.method public setCheckTelephony(Z)Lcom/igg/util/EmulatorDetector;
    .locals 0
    .param p1, "telephony"    # Z

    .prologue
    .line 148
    iput-boolean p1, p0, Lcom/igg/util/EmulatorDetector;->isTelephony:Z

    .line 149
    return-object p0
.end method

.method public setDebug(Z)Lcom/igg/util/EmulatorDetector;
    .locals 0
    .param p1, "isDebug"    # Z

    .prologue
    .line 135
    iput-boolean p1, p0, Lcom/igg/util/EmulatorDetector;->isDebug:Z

    .line 136
    return-object p0
.end method
