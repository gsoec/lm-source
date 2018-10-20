.class public final Lcom/alipay/android/phone/mrpc/core/k;
.super Ljava/lang/Object;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/alipay/android/phone/mrpc/core/k$a;
    }
.end annotation


# static fields
.field private static final A:I = 0x2ed4600e

.field private static final B:I = 0x7ce07427

.field private static final C:I = -0x2e3b8122

.field private static final D:I = 0x714f9fb5

.field private static final E:I = 0x110aef9d

.field private static final F:I = -0xe7c74b5

.field private static final G:I = -0x11fc9c2c

.field private static final H:I = -0x4b88f79d

.field private static final I:I = 0x53476b3b

.field private static final J:I = -0x4e0958cc

.field private static final K:I = -0xc71a9ee

.field private static final L:I = 0x8f17c20

.field private static final M:I = 0x2fa915

.field private static final N:I = 0x49be662f

.field private static final O:I = -0x3a6d1ac4

.field private static final P:I = 0x40b292db

.field private static final Q:I = -0x5034229e

.field private static final R:I = 0x0

.field private static final S:I = 0x1

.field private static final T:I = 0x2

.field private static final U:I = 0x3

.field private static final V:I = 0x4

.field private static final W:I = 0x5

.field private static final X:I = 0x6

.field private static final Y:I = 0x7

.field private static final Z:I = 0x8

.field public static final a:I = 0x1

.field private static final aa:I = 0x9

.field private static final ab:I = 0xa

.field private static final ac:I = 0xb

.field private static final ad:I = 0xc

.field private static final ae:I = 0xd

.field private static final af:I = 0xe

.field private static final ag:I = 0xf

.field private static final ah:I = 0x10

.field private static final ai:I = 0x11

.field private static final aj:I = 0x12

.field private static final ak:I = 0x13

.field private static final aq:[Ljava/lang/String;

.field public static final b:I = 0x2

.field public static final c:I = 0x0

.field public static final d:J = 0x0L

.field public static final e:J = -0x1L

.field public static final f:Ljava/lang/String; = "transfer-encoding"

.field public static final g:Ljava/lang/String; = "content-length"

.field public static final h:Ljava/lang/String; = "content-type"

.field public static final i:Ljava/lang/String; = "content-encoding"

.field public static final j:Ljava/lang/String; = "connection"

.field public static final k:Ljava/lang/String; = "location"

.field public static final l:Ljava/lang/String; = "proxy-connection"

.field public static final m:Ljava/lang/String; = "www-authenticate"

.field public static final n:Ljava/lang/String; = "proxy-authenticate"

.field public static final o:Ljava/lang/String; = "content-disposition"

.field public static final p:Ljava/lang/String; = "accept-ranges"

.field public static final q:Ljava/lang/String; = "expires"

.field public static final r:Ljava/lang/String; = "cache-control"

.field public static final s:Ljava/lang/String; = "last-modified"

.field public static final t:Ljava/lang/String; = "etag"

.field public static final u:Ljava/lang/String; = "set-cookie"

.field public static final v:Ljava/lang/String; = "pragma"

.field public static final w:Ljava/lang/String; = "refresh"

.field public static final x:Ljava/lang/String; = "x-permitted-cross-domain-policies"

.field private static final y:I = 0x4bf6b0f5

.field private static final z:I = -0x4384d946


# instance fields
.field private al:J

.field private am:J

.field private an:I

.field private ao:Ljava/util/ArrayList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/ArrayList",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private ap:[Ljava/lang/String;

.field private ar:Ljava/util/ArrayList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/ArrayList",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private as:Ljava/util/ArrayList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/ArrayList",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 3

    const/16 v0, 0x13

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "transfer-encoding"

    aput-object v2, v0, v1

    const/4 v1, 0x1

    const-string v2, "content-length"

    aput-object v2, v0, v1

    const/4 v1, 0x2

    const-string v2, "content-type"

    aput-object v2, v0, v1

    const/4 v1, 0x3

    const-string v2, "content-encoding"

    aput-object v2, v0, v1

    const/4 v1, 0x4

    const-string v2, "connection"

    aput-object v2, v0, v1

    const/4 v1, 0x5

    const-string v2, "location"

    aput-object v2, v0, v1

    const/4 v1, 0x6

    const-string v2, "proxy-connection"

    aput-object v2, v0, v1

    const/4 v1, 0x7

    const-string v2, "www-authenticate"

    aput-object v2, v0, v1

    const/16 v1, 0x8

    const-string v2, "proxy-authenticate"

    aput-object v2, v0, v1

    const/16 v1, 0x9

    const-string v2, "content-disposition"

    aput-object v2, v0, v1

    const/16 v1, 0xa

    const-string v2, "accept-ranges"

    aput-object v2, v0, v1

    const/16 v1, 0xb

    const-string v2, "expires"

    aput-object v2, v0, v1

    const/16 v1, 0xc

    const-string v2, "cache-control"

    aput-object v2, v0, v1

    const/16 v1, 0xd

    const-string v2, "last-modified"

    aput-object v2, v0, v1

    const/16 v1, 0xe

    const-string v2, "etag"

    aput-object v2, v0, v1

    const/16 v1, 0xf

    const-string v2, "set-cookie"

    aput-object v2, v0, v1

    const/16 v1, 0x10

    const-string v2, "pragma"

    aput-object v2, v0, v1

    const/16 v1, 0x11

    const-string v2, "refresh"

    aput-object v2, v0, v1

    const/16 v1, 0x12

    const-string v2, "x-permitted-cross-domain-policies"

    aput-object v2, v0, v1

    sput-object v0, Lcom/alipay/android/phone/mrpc/core/k;->aq:[Ljava/lang/String;

    return-void
.end method

.method public constructor <init>()V
    .locals 3

    const/4 v2, 0x4

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    new-instance v0, Ljava/util/ArrayList;

    const/4 v1, 0x2

    invoke-direct {v0, v1}, Ljava/util/ArrayList;-><init>(I)V

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ao:Ljava/util/ArrayList;

    const/16 v0, 0x13

    new-array v0, v0, [Ljava/lang/String;

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0, v2}, Ljava/util/ArrayList;-><init>(I)V

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ar:Ljava/util/ArrayList;

    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0, v2}, Ljava/util/ArrayList;-><init>(I)V

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->as:Ljava/util/ArrayList;

    const-wide/16 v0, 0x0

    iput-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->al:J

    const-wide/16 v0, -0x1

    iput-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->am:J

    const/4 v0, 0x0

    iput v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->an:I

    return-void
.end method

.method private a()J
    .locals 2

    iget-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->al:J

    return-wide v0
.end method

.method private a(J)V
    .locals 1

    iput-wide p1, p0, Lcom/alipay/android/phone/mrpc/core/k;->am:J

    return-void
.end method

.method private a(Ljava/lang/String;)V
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/4 v1, 0x2

    aput-object p1, v0, v1

    return-void
.end method

.method private a(Lorg/apache/http/util/CharArrayBuffer;)V
    .locals 8

    .prologue
    const/4 v1, -0x1

    const/4 v2, 0x0

    const/16 v7, 0xc

    .line 0
    .line 1000
    invoke-virtual {p1}, Lorg/apache/http/util/CharArrayBuffer;->length()I

    move-result v3

    invoke-virtual {p1}, Lorg/apache/http/util/CharArrayBuffer;->buffer()[C

    move-result-object v4

    move v0, v2

    :goto_0
    if-ge v0, v3, :cond_3

    aget-char v5, v4, v0

    const/16 v6, 0x3a

    if-ne v5, v6, :cond_1

    .line 0
    :goto_1
    if-ne v0, v1, :cond_4

    :cond_0
    :goto_2
    return-void

    .line 1000
    :cond_1
    const/16 v6, 0x41

    if-lt v5, v6, :cond_2

    const/16 v6, 0x5a

    if-gt v5, v6, :cond_2

    add-int/lit8 v5, v5, 0x20

    int-to-char v5, v5

    aput-char v5, v4, v0

    :cond_2
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_3
    move v0, v1

    goto :goto_1

    .line 0
    :cond_4
    invoke-virtual {p1, v2, v0}, Lorg/apache/http/util/CharArrayBuffer;->substringTrimmed(II)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/String;->length()I

    move-result v3

    if-eqz v3, :cond_0

    add-int/lit8 v0, v0, 0x1

    invoke-virtual {p1}, Lorg/apache/http/util/CharArrayBuffer;->length()I

    move-result v3

    invoke-virtual {p1, v0, v3}, Lorg/apache/http/util/CharArrayBuffer;->substringTrimmed(II)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1}, Ljava/lang/String;->hashCode()I

    move-result v4

    sparse-switch v4, :sswitch_data_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ar:Ljava/util/ArrayList;

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->as:Ljava/util/ArrayList;

    invoke-virtual {v0, v3}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_2

    :sswitch_0
    const-string v4, "transfer-encoding"

    invoke-virtual {v1, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    aput-object v3, v1, v2

    sget-object v1, Lorg/apache/http/message/BasicHeaderValueParser;->DEFAULT:Lorg/apache/http/message/BasicHeaderValueParser;

    new-instance v2, Lorg/apache/http/message/ParserCursor;

    invoke-virtual {p1}, Lorg/apache/http/util/CharArrayBuffer;->length()I

    move-result v4

    invoke-direct {v2, v0, v4}, Lorg/apache/http/message/ParserCursor;-><init>(II)V

    invoke-virtual {v1, p1, v2}, Lorg/apache/http/message/BasicHeaderValueParser;->parseElements(Lorg/apache/http/util/CharArrayBuffer;Lorg/apache/http/message/ParserCursor;)[Lorg/apache/http/HeaderElement;

    move-result-object v0

    array-length v1, v0

    const-string v2, "identity"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v2

    if-nez v2, :cond_5

    if-lez v1, :cond_5

    const-string v2, "chunked"

    add-int/lit8 v1, v1, -0x1

    aget-object v0, v0, v1

    invoke-interface {v0}, Lorg/apache/http/HeaderElement;->getName()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v2, v0}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_5

    const-wide/16 v0, -0x2

    iput-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->al:J

    goto :goto_2

    :cond_5
    const-wide/16 v0, -0x1

    iput-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->al:J

    goto :goto_2

    :sswitch_1
    const-string v0, "content-length"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/4 v1, 0x1

    aput-object v3, v0, v1

    :try_start_0
    invoke-static {v3}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v0

    iput-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->am:J
    :try_end_0
    .catch Ljava/lang/NumberFormatException; {:try_start_0 .. :try_end_0} :catch_0

    goto/16 :goto_2

    :catch_0
    move-exception v0

    goto/16 :goto_2

    :sswitch_2
    const-string v0, "content-type"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/4 v1, 0x2

    aput-object v3, v0, v1

    goto/16 :goto_2

    :sswitch_3
    const-string v0, "content-encoding"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/4 v1, 0x3

    aput-object v3, v0, v1

    goto/16 :goto_2

    :sswitch_4
    const-string v2, "connection"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/4 v2, 0x4

    aput-object v3, v1, v2

    invoke-direct {p0, p1, v0}, Lcom/alipay/android/phone/mrpc/core/k;->a(Lorg/apache/http/util/CharArrayBuffer;I)V

    goto/16 :goto_2

    :sswitch_5
    const-string v0, "location"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/4 v1, 0x5

    aput-object v3, v0, v1

    goto/16 :goto_2

    :sswitch_6
    const-string v2, "proxy-connection"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/4 v2, 0x6

    aput-object v3, v1, v2

    invoke-direct {p0, p1, v0}, Lcom/alipay/android/phone/mrpc/core/k;->a(Lorg/apache/http/util/CharArrayBuffer;I)V

    goto/16 :goto_2

    :sswitch_7
    const-string v0, "www-authenticate"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/4 v1, 0x7

    aput-object v3, v0, v1

    goto/16 :goto_2

    :sswitch_8
    const-string v0, "proxy-authenticate"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0x8

    aput-object v3, v0, v1

    goto/16 :goto_2

    :sswitch_9
    const-string v0, "content-disposition"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0x9

    aput-object v3, v0, v1

    goto/16 :goto_2

    :sswitch_a
    const-string v0, "accept-ranges"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0xa

    aput-object v3, v0, v1

    goto/16 :goto_2

    :sswitch_b
    const-string v0, "expires"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0xb

    aput-object v3, v0, v1

    goto/16 :goto_2

    :sswitch_c
    const-string v0, "cache-control"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    aget-object v0, v0, v7

    if-eqz v0, :cond_6

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    aget-object v0, v0, v7

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v0

    if-lez v0, :cond_6

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    aget-object v2, v1, v7

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const/16 v2, 0x2c

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    aput-object v0, v1, v7

    goto/16 :goto_2

    :cond_6
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    aput-object v3, v0, v7

    goto/16 :goto_2

    :sswitch_d
    const-string v0, "last-modified"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0xd

    aput-object v3, v0, v1

    goto/16 :goto_2

    :sswitch_e
    const-string v0, "etag"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0xe

    aput-object v3, v0, v1

    goto/16 :goto_2

    :sswitch_f
    const-string v0, "set-cookie"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0xf

    aput-object v3, v0, v1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ao:Ljava/util/ArrayList;

    invoke-virtual {v0, v3}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto/16 :goto_2

    :sswitch_10
    const-string v0, "pragma"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0x10

    aput-object v3, v0, v1

    goto/16 :goto_2

    :sswitch_11
    const-string v0, "refresh"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0x11

    aput-object v3, v0, v1

    goto/16 :goto_2

    :sswitch_12
    const-string v0, "x-permitted-cross-domain-policies"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0x12

    aput-object v3, v0, v1

    goto/16 :goto_2

    :sswitch_data_0
    .sparse-switch
        -0x5034229e -> :sswitch_12
        -0x4e0958cc -> :sswitch_b
        -0x4b88f79d -> :sswitch_9
        -0x4384d946 -> :sswitch_1
        -0x3a6d1ac4 -> :sswitch_10
        -0x2e3b8122 -> :sswitch_4
        -0x11fc9c2c -> :sswitch_8
        -0xe7c74b5 -> :sswitch_7
        -0xc71a9ee -> :sswitch_c
        0x2fa915 -> :sswitch_e
        0x8f17c20 -> :sswitch_d
        0x110aef9d -> :sswitch_6
        0x2ed4600e -> :sswitch_2
        0x40b292db -> :sswitch_11
        0x49be662f -> :sswitch_f
        0x4bf6b0f5 -> :sswitch_0
        0x53476b3b -> :sswitch_a
        0x714f9fb5 -> :sswitch_5
        0x7ce07427 -> :sswitch_3
    .end sparse-switch
.end method

.method private a(Lorg/apache/http/util/CharArrayBuffer;I)V
    .locals 1

    const-string v0, "Close"

    invoke-static {p1, p2, v0}, Lcom/alipay/android/phone/mrpc/core/g;->a(Lorg/apache/http/util/CharArrayBuffer;ILjava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_1

    const/4 v0, 0x1

    iput v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->an:I

    :cond_0
    :goto_0
    return-void

    :cond_1
    const-string v0, "Keep-Alive"

    invoke-static {p1, p2, v0}, Lcom/alipay/android/phone/mrpc/core/g;->a(Lorg/apache/http/util/CharArrayBuffer;ILjava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 v0, 0x2

    iput v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->an:I

    goto :goto_0
.end method

.method private b()J
    .locals 2

    iget-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->am:J

    return-wide v0
.end method

.method private b(Ljava/lang/String;)V
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/4 v1, 0x3

    aput-object p1, v0, v1

    return-void
.end method

.method private c()I
    .locals 1

    iget v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->an:I

    return v0
.end method

.method private c(Ljava/lang/String;)V
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/4 v1, 0x5

    aput-object p1, v0, v1

    return-void
.end method

.method private d()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/4 v1, 0x2

    aget-object v0, v0, v1

    return-object v0
.end method

.method private d(Ljava/lang/String;)V
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/4 v1, 0x7

    aput-object p1, v0, v1

    return-void
.end method

.method private e()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/4 v1, 0x3

    aget-object v0, v0, v1

    return-object v0
.end method

.method private e(Ljava/lang/String;)V
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0x8

    aput-object p1, v0, v1

    return-void
.end method

.method private f()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/4 v1, 0x5

    aget-object v0, v0, v1

    return-object v0
.end method

.method private f(Ljava/lang/String;)V
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0x9

    aput-object p1, v0, v1

    return-void
.end method

.method private g()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/4 v1, 0x7

    aget-object v0, v0, v1

    return-object v0
.end method

.method private g(Ljava/lang/String;)V
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0xa

    aput-object p1, v0, v1

    return-void
.end method

.method private h()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0x8

    aget-object v0, v0, v1

    return-object v0
.end method

.method private h(Ljava/lang/String;)V
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0xb

    aput-object p1, v0, v1

    return-void
.end method

.method private i()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0x9

    aget-object v0, v0, v1

    return-object v0
.end method

.method private i(Ljava/lang/String;)V
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0xc

    aput-object p1, v0, v1

    return-void
.end method

.method private j()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0xa

    aget-object v0, v0, v1

    return-object v0
.end method

.method private j(Ljava/lang/String;)V
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0xd

    aput-object p1, v0, v1

    return-void
.end method

.method private k()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0xb

    aget-object v0, v0, v1

    return-object v0
.end method

.method private k(Ljava/lang/String;)V
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0xe

    aput-object p1, v0, v1

    return-void
.end method

.method private l()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0xc

    aget-object v0, v0, v1

    return-object v0
.end method

.method private l(Ljava/lang/String;)V
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0x12

    aput-object p1, v0, v1

    return-void
.end method

.method private m()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0xd

    aget-object v0, v0, v1

    return-object v0
.end method

.method private n()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0xe

    aget-object v0, v0, v1

    return-object v0
.end method

.method private o()Ljava/util/ArrayList;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/ArrayList",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ao:Ljava/util/ArrayList;

    return-object v0
.end method

.method private p()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0x10

    aget-object v0, v0, v1

    return-object v0
.end method

.method private q()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0x11

    aget-object v0, v0, v1

    return-object v0
.end method

.method private r()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ap:[Ljava/lang/String;

    const/16 v1, 0x12

    aget-object v0, v0, v1

    return-object v0
.end method

.method private s()V
    .locals 3

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/k;->ar:Ljava/util/ArrayList;

    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result v1

    const/4 v0, 0x0

    :goto_0
    if-ge v0, v1, :cond_0

    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/k;->ar:Ljava/util/ArrayList;

    invoke-virtual {v2, v0}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/k;->as:Ljava/util/ArrayList;

    invoke-virtual {v2, v0}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method
